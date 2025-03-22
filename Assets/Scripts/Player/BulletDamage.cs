using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public int damage = 1; // Шкода, яку завдає куля персонажа

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Перевірка, чи зіткнувся з об'єктом, який має тег "Enemy"
        if (collision.CompareTag("Enemy"))
        {
            // Отримуємо компонент EnemyHP у ворога і наносимо шкоду
            EnemyHP enemyHP = collision.GetComponent<EnemyHP>();
            if (enemyHP != null)
            {
                enemyHP.TakeDamage(damage); // Наносимо шкоду ворогу
            }

            Destroy(gameObject); // Знищуємо кулю після попадання
        }
    }
}
