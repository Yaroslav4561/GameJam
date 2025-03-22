using UnityEngine;
using System.Collections;

public class SlimeAI : MonoBehaviour
{
    public Transform BlueWizard; // Ціль (гравець)
    public float wanderSpeed = 2f; // Швидкість блукання
    public float chaseSpeed = 4f; // Швидкість переслідування
    public float attackRange = 0.5f; // Дистанція для атаки
    public float visionRange = 5f; // Дистанція огляду
    public float wanderInterval = 2f; // Інтервал між блуканням
    public LayerMask obstacleLayer; // Шар для перевірки перешкод

    private Rigidbody2D rb;
    private Vector3 wanderTarget;
    private bool isChasing = false; // Чи переслідує ворог
    private bool isAttacking = false; // Чи атакує ворог

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WanderRoutine()); // Починаємо блукання
    }

    void Update()
    {
        if (BlueWizard == null) return; // Перевірка, чи існує гравець

        float distanceToPlayer = Vector2.Distance(transform.position, BlueWizard.position);
        bool canSeePlayer = CanSeePlayer();

        if (distanceToPlayer <= attackRange && canSeePlayer)
        {
            if (!isAttacking)
                StartCoroutine(AttackRoutine());
        }
        else if (canSeePlayer)
        {
            StopCoroutine(WanderRoutine());
            ChasePlayer();
        }
        else if (!isChasing && !isAttacking)
        {
            StartCoroutine(WanderRoutine());
        }
    }

    bool CanSeePlayer()
    {
        if (BlueWizard == null) return false;

        Vector2 directionToPlayer = (BlueWizard.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, BlueWizard.position);

        if (distanceToPlayer > visionRange) return false; // Гравець за межами огляду

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer);
        Debug.DrawRay(transform.position, directionToPlayer * distanceToPlayer, Color.red, 0.1f);

        return hit.collider == null; // Якщо немає перешкод, гравця видно
    }

    void ChasePlayer()
    {
        isChasing = true;

        Vector2 moveDirection = (BlueWizard.position - transform.position).normalized;
        rb.velocity = moveDirection * chaseSpeed;

        if (Vector2.Distance(transform.position, BlueWizard.position) <= attackRange)
        {
            rb.velocity = Vector2.zero; // Зупинка перед атакою
            isChasing = false;
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        rb.velocity = Vector2.zero; // Зупинка перед атакою

        Debug.Log("Slime attacks!"); // Атака, тут можна додати логіку (наприклад, нанесення шкоди)

        yield return new WaitForSeconds(1f); // Затримка між атаками
        isAttacking = false;
    }

    IEnumerator WanderRoutine()
    {
        while (true)
        {
            if (isChasing || isAttacking) yield break;

            SetRandomWanderTarget();
            Vector2 moveDirection = (wanderTarget - transform.position).normalized;
            rb.velocity = moveDirection * wanderSpeed;

            yield return new WaitForSeconds(wanderInterval);
            rb.velocity = Vector2.zero;

            yield return new WaitForSeconds(Random.Range(1f, 3f)); // Затримка перед наступним рухом
        }
    }

    void SetRandomWanderTarget()
    {
        wanderTarget = new Vector3(
            transform.position.x + Random.Range(-3f, 3f),
            transform.position.y + Random.Range(-3f, 3f),
            transform.position.z
        );
    }
}