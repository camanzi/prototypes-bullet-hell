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
        if (!enabled) return;

        controller = collision.GetComponent<ShooterController>();

        if (controller.equippedWeapon?.GetGameObject() != gameObject) 
        { 
            collectorTransform = collision.transform;
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
        collectedWeapon.GetTransform().rotation = collectorTransform.rotation;

        collectedWeapon.GetTransform().SetParent(collectorTransform);
        controller.equippedWeapon = collectedWeapon;
    }
}
