using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Переконайся, що BlueWizard має тег "Player"
        {
            Destroy(gameObject); // Знищуємо кулю при попаданні
        }
    }
}
