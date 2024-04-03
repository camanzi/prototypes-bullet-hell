using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject virtualCamera;

    private RoomController roomController;

    private void Awake()
    {
        roomController = GetComponentInParent<RoomController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        roomController.checkForEnemies();
        virtualCamera.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        virtualCamera.SetActive(false);
    }
}
