using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShootingObject : MonoBehaviour, IShooting
{

    public BaseShootableObject projectileToShoot;
    public CollectableObject collectableScript;
    protected float defaultCooldown = 0.25f;

    protected bool isInCooldown = false;

    private void Awake()
    {
        collectableScript = gameObject.GetComponent<CollectableObject>();
    }

    public void shoot(Transform shooterTransform)
    {
        shoot(shooterTransform, 0, defaultCooldown);
    }

    public void shoot(Transform shooterTransform, LayerMask bulletLayer)
    {
        shoot(shooterTransform, bulletLayer, defaultCooldown);
    }

    public void shoot(Transform shooterTransform, LayerMask bulletLayer, float cooldown)
    {
        if (!isInCooldown)
        {
            BaseShootableObject projectile = GameObject.Instantiate<BaseShootableObject>(projectileToShoot, shooterTransform.position, shooterTransform.rotation, null);
            projectile.gameObject.layer = bulletLayer;
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

    public CollectableObject GetCollectableScript()
    {
        return collectableScript;
    }

    private IEnumerator cooldownCoroutine(float cooldown) 
    {
        isInCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isInCooldown = false;
    }
}
