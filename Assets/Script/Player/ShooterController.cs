using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{
    public BaseShootingObject equippedWeapon;

    private void Awake()
    {
        InputManager.InputSystem.GamePlay.Shooting.performed += shoot;
    }

    private void shoot(InputAction.CallbackContext context)
    {
        equippedWeapon.shoot(gameObject.transform, gameObject.transform.position);
    }
}
