using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRotation : AiComponent
{

    public float rotationSpeed = 10f;

    private void Update()
    {
        if (isAiActive)
        {        
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}
