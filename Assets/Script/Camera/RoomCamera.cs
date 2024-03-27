using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject virtualCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        virtualCamera.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        virtualCamera.SetActive(false);
    }
}
