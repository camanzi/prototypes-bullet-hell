using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private NavMeshAgent agent;
    private RoomController roomController;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        roomController = GetComponentInParent<RoomController>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        roomController.onStartEnemyAi += setTargetTransform;
    }

    private void Update()
    {
        if (target)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnDestroy()
    {
        roomController.onStartEnemyAi -= setTargetTransform;
    }

    private void setTargetTransform() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
