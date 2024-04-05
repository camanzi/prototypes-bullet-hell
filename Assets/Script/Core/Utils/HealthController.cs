using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class HealthController : MonoBehaviour
{

    public UnityAction deathEvent;

    [SerializeField]
    private float health = 3f;

    [SerializeField]
    private float immunityTimer = 3f;

    public bool isPlayer = false;

    private bool isImmune = false;

    public void takeDamage(float damage) 
    {
        if (!isImmune)
        { 
            StartCoroutine(loseHealthCoroutine(damage));
        }
    }

    private IEnumerator loseHealthCoroutine(float damage)
    {
        isImmune = true;
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            if (isPlayer) 
            {
                GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.GameOver;
            } else {
                deathEvent?.Invoke();
            }
        }
        yield return new WaitForSeconds(immunityTimer);
        isImmune = false;
    }
}
