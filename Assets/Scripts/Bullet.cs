using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // �����������, �� BlueWizard �� ��� "Player"
        {
            Destroy(gameObject); // ������� ���� ��� ��������
        }
    }
}
