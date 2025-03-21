using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject bulletPrefab;  // Префаб кулі
    public Transform attackPoint;    // Точка, з якої буде вистрілювати куля
    public float bulletSpeed = 10f;  // Швидкість кулі

    private PlayerMovement playerMovement;  // Силует гравця для доступу до isFacingRight

    void Start()
    {
        // Отримуємо компонент PlayerMovement для доступу до isFacingRight
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))  // Перевіряємо натискання клавіші J
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Визначаємо напрямок стрільби
        float direction = playerMovement.isFacingRight ? 1f : -1f;

        // Визначаємо позицію появи кулі попереду персонажа
        Vector3 spawnPosition = attackPoint.position + new Vector3(direction * 0.5f, 0f, 0f);

        // Створюємо кулю
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        // Отримуємо компонент Rigidbody2D кулі
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Визначаємо напрямок польоту кулі
        rb.velocity = new Vector2(direction * bulletSpeed, 0f);

        // Інвертуємо масштаб кулі, щоб вона відображалась у правильному напрямку
        Vector3 bulletScale = bullet.transform.localScale;
        bulletScale.x = Mathf.Abs(bulletScale.x) * direction;
        bullet.transform.localScale = bulletScale;
    }
}
