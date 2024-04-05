using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutomaticShooting : AiComponent
{
    public float cooldown = 1f;
    private ShooterController shooterController;

    public override void Awake()
    {
        base.Awake();
        shooterController = GetComponent<ShooterController>();
    }

    private void Update()
    {
        if (isAiActive)
        {
            shooterController.shoot(cooldown);
        }
    }
}
