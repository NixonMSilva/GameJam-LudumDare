using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public GameObject destination;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Vector3 teleportPosition = destination.transform.position;
            teleportPosition.z = 0f;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = teleportPosition;
        }
    }
}
