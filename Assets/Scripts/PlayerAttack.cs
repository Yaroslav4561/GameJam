using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject bulletPrefab;  // ������ ���
    public Transform attackPoint;    // �����, � ��� ���� ����������� ����
    public float bulletSpeed = 10f;  // �������� ���

    private PlayerMovement playerMovement;  // ������ ������ ��� ������� �� isFacingRight

    void Start()
    {
        // �������� ��������� PlayerMovement ��� ������� �� isFacingRight
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))  // ���������� ���������� ������ J
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // ��������� �������� �������
        float direction = playerMovement.isFacingRight ? 1f : -1f;

        // ��������� ������� ����� ��� �������� ���������
        Vector3 spawnPosition = attackPoint.position + new Vector3(direction * 0.5f, 0f, 0f);

        // ��������� ����
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        // �������� ��������� Rigidbody2D ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // ��������� �������� ������� ���
        rb.velocity = new Vector2(direction * bulletSpeed, 0f);

        // ��������� ������� ���, ��� ���� ������������ � ����������� ��������
        Vector3 bulletScale = bullet.transform.localScale;
        bulletScale.x = Mathf.Abs(bulletScale.x) * direction;
        bullet.transform.localScale = bulletScale;
    }
}
