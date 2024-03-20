using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooting
{
    public void shoot(Transform position);
    public void shoot(Transform position, LayerMask bulletLayer);
    public void shoot(Transform position, LayerMask bulletLayer, float cooldown);
    public CollectableObject GetCollectableScript();
    public Transform GetTransform();

    public GameObject GetGameObject();
}
