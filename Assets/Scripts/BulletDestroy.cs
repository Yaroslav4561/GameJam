using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject); // Знищуємо кулю
        }
    }

}
