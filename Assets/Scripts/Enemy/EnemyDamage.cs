using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int damage = 1; // �����, ��� ����� ���� ������

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ��������, �� �������� � ����������
        {
            // �������� ��������� CharacterHP � ��������� � �������� �����
            CharacterHP playerHP = collision.GetComponent<CharacterHP>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(damage); // �������� �����
            }

            Destroy(gameObject); // ������� ���� ���� ���������
        }
    }
}
