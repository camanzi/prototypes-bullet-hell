using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float health = 3f;

    [SerializeField]
    private float immunityTimer = 3f;

    [SerializeField]
    private bool isPlayer = false;

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
            GameObject.Destroy(gameObject);
            if (isPlayer) 
            {
                GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.GameOver;
            }
        }
        yield return new WaitForSeconds(immunityTimer);
        isImmune = false;
    }
}
