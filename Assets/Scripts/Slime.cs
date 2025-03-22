using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    public Transform blueWizard;
    public float patrolSpeed = 1f; // Повільна швидкість патрулювання
    public float chaseSpeed = 3f;  // Швидкість переслідування
    public float jumpForce = 250f; // Сила стрибка
    public float attackRange = 1.5f;
    public float actionInterval = 1f;

    private Rigidbody2D rb;
    private float nextActionTime = 0;
    private bool seesPlayer = false;
    private Vector2 patrolDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomPatrolDirection();
    }

    void Update()
    {
        seesPlayer = CanSeePlayer();

        if (Time.time >= nextActionTime)
        {
            if (seesPlayer)
            {
                MoveTowardsPlayer(chaseSpeed);

                if (Random.value < 0.3f) // 30% шанс стрибка
                {
                    Jump();
                }
            }
            else
            {
                Patrol();
            }

            nextActionTime = Time.time + actionInterval;
        }
    }

    void MoveTowardsPlayer(float speed)
    {
        Vector2 direction = (blueWizard.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    void Patrol()
    {
        if (Random.value < 0.02f) // Зміна напряму іноді
        {
            SetRandomPatrolDirection();
        }

        rb.velocity = new Vector2(patrolDirection.x * patrolSpeed, rb.velocity.y);
    }

    void SetRandomPatrolDirection()
    {
        patrolDirection = Random.value > 0.5f ? Vector2.right : Vector2.left;
    }

    void Jump()
    {
        if (Mathf.Approximately(rb.velocity.y, 0))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    bool CanSeePlayer()
    {
        Vector2 direction = (blueWizard.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, attackRange);

        if (hit.collider != null && hit.collider.transform == blueWizard)
        {
            return true;
        }

        return false;
    }
}
