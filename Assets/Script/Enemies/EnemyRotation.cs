using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRotation : AiComponent
{
    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField]
    private bool isAimingPlayer = false;
    
    private Transform target;

    private void Update()
    {
        if (!isAiActive) { return;  }

        if (!isAimingPlayer)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        } else {
            Vector3 targetDirection = target.position;
            Vector3 enemyPosition = transform.position;

            targetDirection.x -= enemyPosition.x;
            targetDirection.y -= enemyPosition.y;

            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }

    public override void activateAi()
    {
        if (isAimingPlayer) 
        { 
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        base.activateAi();
    }
}
