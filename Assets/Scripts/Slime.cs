using UnityEngine;
using System.Collections;

public class SlimeAI : MonoBehaviour
{
    public Transform BlueWizard; // ֳ�� (�������)
    public float wanderSpeed = 2f; // �������� ��������
    public float chaseSpeed = 4f; // �������� �������������
    public float attackRange = 0.5f; // ��������� ��� �����
    public float visionRange = 5f; // ��������� ������
    public float wanderInterval = 2f; // �������� �� ���������
    public LayerMask obstacleLayer; // ��� ��� �������� ��������

    private Rigidbody2D rb;
    private Vector3 wanderTarget;
    private bool isChasing = false; // �� �������� �����
    private bool isAttacking = false; // �� ����� �����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WanderRoutine()); // �������� ��������
    }

    void Update()
    {
        if (BlueWizard == null) return; // ��������, �� ���� �������

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

        if (distanceToPlayer > visionRange) return false; // ������� �� ������ ������

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer);
        Debug.DrawRay(transform.position, directionToPlayer * distanceToPlayer, Color.red, 0.1f);

        return hit.collider == null; // ���� ���� ��������, ������ �����
    }

    void ChasePlayer()
    {
        isChasing = true;

        Vector2 moveDirection = (BlueWizard.position - transform.position).normalized;
        rb.velocity = moveDirection * chaseSpeed;

        if (Vector2.Distance(transform.position, BlueWizard.position) <= attackRange)
        {
            rb.velocity = Vector2.zero; // ������� ����� ������
            isChasing = false;
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        rb.velocity = Vector2.zero; // ������� ����� ������

        Debug.Log("Slime attacks!"); // �����, ��� ����� ������ ����� (���������, ��������� �����)

        yield return new WaitForSeconds(1f); // �������� �� �������
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

            yield return new WaitForSeconds(Random.Range(1f, 3f)); // �������� ����� ��������� �����
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