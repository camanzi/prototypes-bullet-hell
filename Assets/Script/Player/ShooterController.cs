using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{
    public BaseShootingObject equippedWeapon 
    {
        get { return _equippedWeapon; }
        set
        {
            changeWeapon(value);
        }
    }

    private BaseShootingObject _equippedWeapon;

    private void Awake()
    {
        InputManager.InputSystem.GamePlay.Shooting.performed += shoot;
        InputManager.InputSystem.GamePlay.DropWeapon.performed += drop;
    }

    private void Start()
    {
        equippedWeapon = gameObject.GetComponentInChildren<BaseShootingObject>();
    }

    private void shoot(InputAction.CallbackContext context)
    {
        _equippedWeapon?.shoot(gameObject.transform, gameObject.transform.position);
    }

    private void drop(InputAction.CallbackContext context)
    {
        changeWeapon(null);
    }

    private void changeWeapon(BaseShootingObject newWeapon) 
    {
        _equippedWeapon?.gameObject.transform.SetParent(null);
        _equippedWeapon = newWeapon;
    }
}
