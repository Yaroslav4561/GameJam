using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Об'єкт, за яким слідує камера (гравець)
    public float smoothSpeed = 0.125f;  // Швидкість згладжування
    public float offsetX = 0f;  // Зсув по осі X
    public float offsetY = 0f;  // Зсув по осі Y

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 currentPosition = transform.position;

        // Плавне слідування за гравцем по X і Y
        float targetX = Mathf.Lerp(currentPosition.x, target.position.x + offsetX, smoothSpeed);
        float targetY = Mathf.Lerp(currentPosition.y, target.position.y + offsetY, smoothSpeed);

        // Оновлення позиції камери
        transform.position = new Vector3(targetX, targetY, currentPosition.z);
    }
}
