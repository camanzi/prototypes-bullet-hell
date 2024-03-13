using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShootingObject : MonoBehaviour, IShooting
{

    public BaseShootableObject projectile;
    protected float cooldown = 0.25f;

    protected bool isInCooldown = false;

    public void shoot(Transform shooterTransform, Vector2 direction)
    {
        if (!isInCooldown) 
        {
            GameObject.Instantiate<BaseShootableObject>(projectile, shooterTransform.position, shooterTransform.rotation, null);
            StartCoroutine(cooldownCoroutine());
        }
    }

    private IEnumerator cooldownCoroutine() 
    {
        isInCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isInCooldown = false;
    }
}
