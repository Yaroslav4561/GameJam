using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public GameObject player;
    public Transform respawnpoint;

    private void OnCollistionEnter2dD(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            {
            player.transform.position = col.transform.position;
        }
    }

}
