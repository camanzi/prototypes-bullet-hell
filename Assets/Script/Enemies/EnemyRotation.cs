using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{

    public float rotationSpeed = 10f;

    private RoomController roomController;
    private bool isAiActive = false;

    private void Awake()
    {
        roomController = GetComponentInParent<RoomController>();
    }

    private void Start()
    {
        roomController.onStartEnemyAi += activateShooting;
    }

    private void Update()
    {
        if (isAiActive)
        {        
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
    private void OnDestroy()
    {
        roomController.onStartEnemyAi -= activateShooting;
    }

    private void activateShooting()
    {
        isAiActive = true;
    }
}
