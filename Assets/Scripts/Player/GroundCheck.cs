using UnityEngine;

public class PlayerFallDeath : MonoBehaviour
{
    public float deathHeight = -10f;  // Висота, нижче якої персонаж помирає (відносно осі Y)
    public int maxHP = 5;  // Максимальне здоров'я
    private int currentHP;  // Поточне здоров'я

    void Start()
    {
        currentHP = maxHP;  // Ініціалізація здоров'я
    }

    void Update()
    {
        CheckFallDeath();  // Перевірка кожен кадр
    }

    // Метод для перевірки, чи персонаж впав за межі карти
    void CheckFallDeath()
    {
        if (transform.position.y < deathHeight)
        {
            Die();  // Викликаємо метод смерті
        }
    }

    // Метод смерті персонажа
    void Die()
    {
        Debug.Log("Персонаж помер через падіння за межі карти.");
        // Наприклад, вимикаємо об'єкт
        gameObject.SetActive(false);  // Зупиняємо гру, де активуємо/деактивуємо об'єкт
    }
}
