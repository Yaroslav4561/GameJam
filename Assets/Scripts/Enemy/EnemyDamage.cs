using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int damage = 1; // Шкода, яку завдає куля ворога

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Перевірка, чи зіткнувся з персонажем
        {
            // Отримуємо компонент CharacterHP у персонажа і наносимо шкоду
            CharacterHP playerHP = collision.GetComponent<CharacterHP>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(damage); // Наносимо шкоду
            }

            Destroy(gameObject); // Знищуємо кулю після попадання
        }
    }
}
