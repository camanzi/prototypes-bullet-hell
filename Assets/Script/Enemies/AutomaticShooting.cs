using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutomaticShooting : MonoBehaviour
{
    private ShooterController shooterController;

    private void Awake()
    {
        shooterController = GetComponent<ShooterController>();
    }

    private void Update()
    {
        shooterController.shoot();
    }
}
