using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmnidirectionalShooting : MonoBehaviour, IShooting
{

    public IShooting[] shootingObjects;
    public CollectableObject collectableScript;
    protected float defaultCooldown = 0.15f;

    protected bool isInCooldown = false;

    private void Awake()
    {
        shootingObjects = gameObject.GetComponentsInChildren<BaseShootingObject>();
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
            for (int i = 0; i < shootingObjects.Length; i++) 
            {
                shootingObjects[i].shoot(shootingObjects[i].GetTransform(), bulletLayer, 0);
            }
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
