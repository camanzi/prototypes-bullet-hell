using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private RoomController roomController;

    private void Awake()
    {
        roomController = GetComponentInParent<RoomController>();

        roomController.onOpenDoorsEvent += OnOpenDoorEvent;
        roomController.onCloseDoorsEvent += OnCloseDoorEvent;
    }

    private void OnOpenDoorEvent()
    {
        gameObject.SetActive(false);
    }

    private void OnCloseDoorEvent() 
    {
        gameObject.SetActive(true);
    }
}
