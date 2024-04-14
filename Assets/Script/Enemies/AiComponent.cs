using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiComponent : MonoBehaviour
{
    private float timerToActivate = 0.1f;

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
        StartCoroutine(AIActivationCoroutine());
    }

    private IEnumerator AIActivationCoroutine()
    { 
        yield return new WaitForSeconds(timerToActivate);
        isAiActive = true;
    }
}
