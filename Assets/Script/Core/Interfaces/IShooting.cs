using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooting
{
    public void shoot(Transform position, float cooldown);
    public void shoot(Transform position);

    public Transform GetTransform();

    public GameObject GetGameObject();
}
