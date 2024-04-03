using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTeleport : MonoBehaviour
{

    [SerializeField]
    private GameObject spawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.transform.position = spawn.transform.position;
    }
}
