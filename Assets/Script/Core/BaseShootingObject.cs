using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShootingObject : MonoBehaviour, IShooting
{

    public BaseShootableObject projectile;
    public void shoot(Transform shooterTransform, Vector2 direction)
    {
        GameObject.Instantiate<BaseShootableObject>(projectile, shooterTransform.position, shooterTransform.rotation, shooterTransform.root);
    }
}
