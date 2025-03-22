using UnityEngine;
using System.Collections;


public class WizardAI : MonoBehaviour
{
    public Transform BlueWizard;
    public GameObject bulletPrefab;
    public LayerMask obstacleLayer; // Шар для перевірки перешкод

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 lastDirection;

    public float attackDistance = 8f;
    public float stopDistance = 6f;
    public float wanderSpeed = 2f;
    public float attackSpeed = 4f;
    public float bulletSpawnInterval = 2f;
    public float bulletSpeed = 5f;

    private Vector3 wanderTarget;
    private float bulletCooldown = 0f;
    private bool isAttacking = false;
    private Vector3 originalScale;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("❌ Rigidbody2D не знайдено! Додай його до " + gameObject.name);
            return;
        }

        lastDirection = Vector2.right;
        originalScale = transform.localScale;
        StartCoroutine(WanderRoutine());
    }

    void Update()
    {
        if (BlueWizard == null) return;

        float speed = rb.velocity.magnitude;
        animator.SetBool("isMoving", speed > 0.1f);
        animator.SetBool("isShooting", false);

        if (rb.velocity.sqrMagnitude > 0)
        {
            Vector2 currentDirection = rb.velocity.normalized;
            FlipCharacter(currentDirection.x < 0);
            animator.SetBool("isTurning", Mathf.Sign(currentDirection.x) != Mathf.Sign(lastDirection.x));
            lastDirection = currentDirection;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, BlueWizard.position);
        bool canSeePlayer = CanSeePlayer();

        if (distanceToPlayer <= attackDistance && !isAttacking && canSeePlayer)
        {
            StopCoroutine(WanderRoutine());
            StartCoroutine(AttackRoutine());
        }
    }
    void ShootBullet()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("❌ bulletPrefab не призначено у " + gameObject.name);
            return;
        }

        animator.SetBool("isShooting", true);
        Invoke("ResetShoot", 0.3f);

        // Отримуємо напрямок до гравця
        Vector2 direction = (BlueWizard.position - transform.position).normalized;

        // Зміщуємо точку появи кулі вперед відносно ворога
        float spawnOffset = 1f; // Відстань перед ворогом
        Vector3 spawnPosition = transform.position + (Vector3)direction * spawnOffset;

        // Створюємо кулю в правильному місці
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb == null)
        {
            Debug.LogError("❌ У bulletPrefab немає Rigidbody2D!");
            return;
        }

        bulletRb.gravityScale = 0;
        bulletRb.velocity = direction * bulletSpeed;

        // Повертаємо кулю в напрямку польоту
        bullet.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        Destroy(bullet, 5f);
    }

    bool CanSeePlayer()
    {
        if (BlueWizard == null) return false;

        Vector2 directionToPlayer = (BlueWizard.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, BlueWizard.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer);

        return hit.collider == null; // Якщо немає перешкод, то бачимо гравця
    }

    IEnumerator AttackRoutine()
    {
        if (isAttacking) yield break;
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);

        while (BlueWizard != null && Vector2.Distance(transform.position, BlueWizard.position) <= attackDistance)
        {
            bool canSeePlayer = CanSeePlayer();
            float distanceToPlayer = Vector2.Distance(transform.position, BlueWizard.position);

            if (distanceToPlayer > stopDistance)
            {
                Vector2 moveDirection = (BlueWizard.position - transform.position).normalized;
                rb.velocity = moveDirection * attackSpeed;
                FlipCharacter(moveDirection.x < 0);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            if (canSeePlayer)
            {
                bulletCooldown -= Time.deltaTime;
                if (bulletCooldown <= 0)
                {
                    ShootBullet();
                    bulletCooldown = bulletSpawnInterval;
                }
            }

            yield return null;
        }

        rb.velocity = Vector2.zero;
        isAttacking = false;
        StartCoroutine(WanderRoutine());
    }

    void ResetShoot()
    {
        animator.SetBool("isShooting", false);
    }

    IEnumerator WanderRoutine()
    {
        while (true)
        {
            if (isAttacking) yield break;

            SetRandomWanderTarget();
            Vector2 moveDirection = (wanderTarget - transform.position).normalized;
            FlipCharacter(moveDirection.x < 0);

            while (Vector3.Distance(transform.position, wanderTarget) > 0.5f)
            {
                if (isAttacking) yield break;
                rb.velocity = moveDirection * wanderSpeed;
                yield return null;
            }

            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    void SetRandomWanderTarget()
    {
        wanderTarget = new Vector3(
            transform.position.x + Random.Range(-5f, 5f),
            transform.position.y,
            transform.position.z
        );
    }

    void FlipCharacter(bool facingLeft)
    {
        transform.localScale = new Vector3(facingLeft ? -originalScale.x : originalScale.x, originalScale.y, originalScale.z);
    }

}
