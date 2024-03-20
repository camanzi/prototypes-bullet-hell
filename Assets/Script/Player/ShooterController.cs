using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{
    public string defaultWeaponLayer;
    public bool useInputSystem = false;
    public IShooting equippedWeapon
    {
        get { return _equippedWeapon; }
        set
        {
            changeWeapon(value);
        }
    }

    private IShooting _equippedWeapon;
    private LayerMask _bulletsLayer;

    private void Awake()
    {
        if (useInputSystem) 
        { 
            InputManager.InputSystem.GamePlay.Shooting.performed += shoot;
            InputManager.InputSystem.GamePlay.DropWeapon.performed += drop;
        }
        _bulletsLayer = gameObject.layer + 1;
    }

    private void Start()
    {
        equippedWeapon = gameObject.GetComponentInChildren<IShooting>();
    }
    public void shoot(float cooldown) 
    {
        _equippedWeapon?.shoot(_equippedWeapon.GetTransform(), _bulletsLayer, cooldown);
    }

    private void shoot(InputAction.CallbackContext context)
    {
        shoot(0);
    }


    public void drop(InputAction.CallbackContext context)
    {
        changeWeapon(null);
    }

    private void changeWeapon(IShooting newWeapon) 
    {
        if (_equippedWeapon != null) 
        {
            _equippedWeapon.GetTransform().SetParent(null);
            _equippedWeapon.GetCollectableScript().enabled = true;
            _equippedWeapon.GetGameObject().layer = LayerMask.NameToLayer(defaultWeaponLayer);
        }
        _equippedWeapon = newWeapon;

        if (_equippedWeapon != null) 
        {
            _equippedWeapon.GetCollectableScript().enabled = false;
            _equippedWeapon.GetGameObject().layer = _bulletsLayer;
        }
    }
}
