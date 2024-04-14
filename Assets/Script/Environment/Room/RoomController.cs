using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomController : MonoBehaviour
{
    private int aliveEnemies = 0;

    public delegate void openDoorsEvent();
    public openDoorsEvent onOpenDoorsEvent;

    public delegate void closeDoorsEvent();
    public closeDoorsEvent onCloseDoorsEvent;

    public delegate void startEnemyAi();
    public closeDoorsEvent onStartEnemyAi;

    private void Start()
    {
        onOpenDoorsEvent?.Invoke();
    }

    public void checkForEnemies() 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent<HealthController>(out HealthController enemyHealthController))
            {
                if (!enemyHealthController.gameObject.CompareTag("Player"))
                    aliveEnemies++;
                enemyHealthController.deathEvent += onEnemyDeath;
            }
        }
        if (aliveEnemies > 0)
        {
            onCloseDoorsEvent?.Invoke();
            onStartEnemyAi?.Invoke();
        }
        else { 
            onOpenDoorsEvent?.Invoke();
        }
    }

    private void onEnemyDeath() 
    {
        aliveEnemies--;
        if (aliveEnemies <= 0)
        {
            onOpenDoorsEvent.Invoke();
        }
    }

}
