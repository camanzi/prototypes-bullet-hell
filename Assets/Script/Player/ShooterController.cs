using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{
    public IShooting equippedWeapon 
    {
        get { return _equippedWeapon; }
        set
        {
            changeWeapon(value);
        }
    }

    private IShooting _equippedWeapon;

    private void Awake()
    {
        InputManager.InputSystem.GamePlay.Shooting.performed += shoot;
        InputManager.InputSystem.GamePlay.DropWeapon.performed += drop;
    }

    private void Start()
    {
        equippedWeapon = gameObject.GetComponentInChildren<IShooting>();
    }

    private void shoot(InputAction.CallbackContext context)
    {
        _equippedWeapon?.shoot(_equippedWeapon.GetTransform());
    }

    private void drop(InputAction.CallbackContext context)
    {
        changeWeapon(null);
    }

    private void changeWeapon(IShooting newWeapon) 
    {
        _equippedWeapon?.GetTransform().SetParent(null);
        _equippedWeapon = newWeapon;
    }
}
