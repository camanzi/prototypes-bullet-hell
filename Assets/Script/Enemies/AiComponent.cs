using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiComponent : MonoBehaviour
{

    protected bool isAiActive = false;

    private RoomController roomController;

    public virtual void Awake()
    {
        roomController = GetComponentInParent<RoomController>();
    }

    public virtual void Start()
    {
        roomController.onStartEnemyAi += activateAi;
    }

    public void OnDestroy()
    {
        roomController.onStartEnemyAi -= activateAi;
    }

    public virtual void activateAi()
    {
        isAiActive = true;
    }
}
