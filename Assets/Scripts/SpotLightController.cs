using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotLightController : MonoBehaviour
{
    public Transform player;   // Посилання на гравця

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform; // Знаходимо гравця за тегом "Player"
        }
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position; // Прив'язуємо світло до гравця
        }
    }
}
