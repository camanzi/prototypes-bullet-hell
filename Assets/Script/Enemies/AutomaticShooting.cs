using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutomaticShooting : MonoBehaviour
{
    public float cooldown = 1f;
    private ShooterController shooterController;
    private RoomController roomController;

    private bool isAiActive = false;

    private void Awake()
    {
        shooterController = GetComponent<ShooterController>();
        roomController = GetComponentInParent<RoomController>();
    }

    private void Start()
    {
        roomController.onStartEnemyAi += activateShooting;
    }

    private void Update()
    {
        if (isAiActive)
        {
            shooterController.shoot(cooldown);
        }
    }

    private void OnDestroy()
    {
        roomController.onStartEnemyAi -= activateShooting;
    }

    private void activateShooting() 
    {
        isAiActive = true;
    }
}
