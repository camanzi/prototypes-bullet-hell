using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject closedDoorMesh;

    [SerializeField]
    private GameObject openDoorMesh;

    private RoomController roomController;

    private void Awake()
    {
        roomController = GetComponentInParent<RoomController>();

        roomController.onOpenDoorsEvent += OnOpenDoorEvent;
        roomController.onCloseDoorsEvent += OnCloseDoorEvent;
    }

    private void OnOpenDoorEvent()
    {
        closedDoorMesh.SetActive(false);
        openDoorMesh.SetActive(true);
    }

    private void OnCloseDoorEvent() 
    {
        closedDoorMesh.SetActive(true);
        openDoorMesh.SetActive(false);
    }
}
