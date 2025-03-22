using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHP = 3; // Максимальне здоров'я ворога
    private int currentHP;

    void Start()
    {
        currentHP = maxHP; // Ініціалізуємо поточне здоров'я на рівні максимального
        Debug.Log("Ворог має " + currentHP + " HP");
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage; // Віднімаємо шкоду від поточного здоров'я
        Debug.Log("Ворог отримав " + damage + " шкоди. Залишилось: " + currentHP + " HP");

        if (currentHP <= 0)
        {
            Die(); // Ворог помирає, якщо здоров'я менше або рівне нулю
        }
    }

    void Die()
    {
        Debug.Log("Ворог помер!");
        // Можна додати анімацію, ефекти або знищення об'єкта
        Destroy(gameObject); // Знищуємо об'єкт ворога
    }
}
