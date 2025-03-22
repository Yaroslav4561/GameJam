using UnityEngine;
using UnityEngine.SceneManagement; // Для роботи з завантаженням сцени

public class CharacterHP : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;

    public float deathHeight = -10f; // Поріг висоти, нижче якого персонаж помирає

    void Start()
    {
        currentHP = maxHP;
        Debug.Log("Персонаж має " + currentHP + " HP");
    }

    void Update()
    {
        // Перевіряємо, чи персонаж випав за межі карти
        CheckFallDeath();
    }

    // Метод для отримання шкоди
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Персонаж отримав " + damage + " шкоди. Залишилось: " + currentHP + " HP");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    // Метод для перевірки падіння за межі карти
    void CheckFallDeath()
    {
        if (transform.position.y < deathHeight)
        {
            Die(); // Персонаж помирає при падінні за межі
        }
    }

    // Метод смерті персонажа
    void Die()
    {
        Debug.Log("Персонаж помер!");

        // Завантажуємо сцену меню після смерті
        SceneManager.LoadScene("Menu"); // Замініть "Menu" на точне ім'я вашої сцени меню
    }
}
