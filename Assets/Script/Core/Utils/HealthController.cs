using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class HealthController : MonoBehaviour
{

    public UnityAction deathEvent;

    public float startingHealth = 3f;
    public float currentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
    private float _currentHealth;

    [SerializeField]
    private float immunityTimer = 3f;

    public bool isPlayer = false;
    
    [HideInInspector]
    public bool isImmune = false;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

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
        _currentHealth -= damage;
        if (_currentHealth <= 0)
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
