using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public int damage = 1; // �����, ��� ����� ���� ���������

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ��������, �� �������� � ��'�����, ���� �� ��� "Enemy"
        if (collision.CompareTag("Enemy"))
        {
            // �������� ��������� EnemyHP � ������ � �������� �����
            EnemyHP enemyHP = collision.GetComponent<EnemyHP>();
            if (enemyHP != null)
            {
                enemyHP.TakeDamage(damage); // �������� ����� ������
            }

            Destroy(gameObject); // ������� ���� ���� ���������
        }
    }
}
