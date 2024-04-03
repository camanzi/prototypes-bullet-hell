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

    private bool doorsHasBeenOpen = false; 
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            if (transform.GetChild(i).TryGetComponent<HealthController>(out HealthController enemyHealthController)) 
            {
                if (!enemyHealthController.isPlayer)
                    aliveEnemies++;
                enemyHealthController.deathEvent += onEnemyDeath;
            }
        }
        if (aliveEnemies > 0)
        {
            onCloseDoorsEvent.Invoke();
        }
    }

    private void Update()
    {
        if (aliveEnemies <= 0 && !doorsHasBeenOpen) 
        {
            onOpenDoorsEvent.Invoke();
            doorsHasBeenOpen = true;
        } 
    }

    private void onEnemyDeath() 
    {
        aliveEnemies--;
    }

}
