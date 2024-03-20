using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShootingObject : MonoBehaviour, IShooting
{

    public BaseShootableObject projectile;
    protected float defaultCooldown = 0.25f;

    protected bool isInCooldown = false;

    public void shoot(Transform shooterTransform)
    {
        shoot(shooterTransform, defaultCooldown);
    }

    public void shoot(Transform shooterTransform, float cooldown)
    {
        if (!isInCooldown) 
        {
            GameObject.Instantiate<BaseShootableObject>(projectile, shooterTransform.position, shooterTransform.rotation, null);
            StartCoroutine(cooldownCoroutine(cooldown));
        }
    }

    public Transform GetTransform() 
    {
        return transform;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    private IEnumerator cooldownCoroutine(float cooldown) 
    {
        isInCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isInCooldown = false;
    }
}
