using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutomaticShooting : MonoBehaviour
{
    public float cooldown = 1f;
    private ShooterController shooterController;

    private void Awake()
    {
        shooterController = GetComponent<ShooterController>();
    }

    private void Update()
    {
        shooterController.shoot(cooldown);
    }
}
