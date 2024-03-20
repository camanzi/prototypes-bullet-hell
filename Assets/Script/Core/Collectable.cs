using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollectableObject : MonoBehaviour
{

    ShooterController controller;
    Transform collectorTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller = collision.GetComponent<ShooterController>();
        collectorTransform = collision.transform;

        if (controller.equippedWeapon?.GetGameObject() != gameObject) 
        { 
            InputManager.InputSystem.GamePlay.CollectWeapon.performed += equip;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        controller = null;
        InputManager.InputSystem.GamePlay.CollectWeapon.performed -= equip;
    }

    private void equip(InputAction.CallbackContext context)
    {
        IShooting collectedWeapon = gameObject.GetComponent<IShooting>();

        collectedWeapon.GetTransform().position = collectorTransform.position;
        collectorTransform.rotation = collectorTransform.rotation;
        
        collectedWeapon.GetTransform().SetParent(collectorTransform);
        controller.equippedWeapon = collectedWeapon;
    }
}
