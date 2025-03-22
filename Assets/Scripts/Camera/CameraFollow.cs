using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    public Transform target;  // Персонаж
    public float smoothSpeed = 0.125f;  // Швидкість слідування
    public float offsetX = 5f;  // Відстань від персонажа по X

    void LateUpdate()
    {
        if (target == null) return;

        // Отримуємо поточну позицію камери
        Vector3 currentPosition = transform.position;

        // Нове значення X для камери (з плавним переходом)
        float targetX = Mathf.Lerp(currentPosition.x, target.position.x + offsetX, smoothSpeed);

        // Призначаємо нову позицію, але залишаємо Y та Z незмінними
        transform.position = new Vector3(targetX, currentPosition.y, currentPosition.z);
    }
}
