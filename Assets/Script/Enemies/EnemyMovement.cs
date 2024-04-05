using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : AiComponent
{

    private Transform target;
    private NavMeshAgent agent;

    public override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (target)
        {
            agent.SetDestination(target.position);
        }
    }

    public override void activateAi() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
