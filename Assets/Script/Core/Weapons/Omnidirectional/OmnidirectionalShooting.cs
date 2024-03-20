using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmnidirectionalShooting : MonoBehaviour, IShooting
{

    public IShooting[] shootingObjects;
    protected float defaultCooldown = 0.15f;

    protected bool isInCooldown = false;

    private void Awake()
    {
        shootingObjects = gameObject.GetComponentsInChildren<BaseShootingObject>();
    }

    public void shoot(Transform shooterTransform)
    {
        shoot(shooterTransform, defaultCooldown);
    }

    public void shoot(Transform shooterTransform, float cooldown)
    {
        if (!isInCooldown) 
        {
            for (int i = 0; i < shootingObjects.Length; i++) 
            {
                shootingObjects[i].shoot(shootingObjects[i].GetTransform(), 0);
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

    private IEnumerator cooldownCoroutine(float cooldown) 
    {
        isInCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isInCooldown = false;
    }
}
