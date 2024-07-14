using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    public event Action deathEvent;
    public event Action damageEvent;

    public int startingHealth = 3;
    public int currentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
    private int _currentHealth;

    [SerializeField]
    private float immunityTimer = 3f;
    public bool isGameFinisher = false;

    [SerializeField] private bool isPlayer = false;
    [HideInInspector] public bool isImmune = false;
    [SerializeField] private Image currentHealthBar;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    private void Update()
    {
        if (currentHealthBar) 
        {
            currentHealthBar.rectTransform.localScale = new Vector3((float) currentHealth / (float) startingHealth, currentHealthBar.rectTransform.localScale.y, currentHealthBar.rectTransform.localScale.z);
        }   
    }
    public void SetCurrentHealthBar(Image healthBar) 
    {
        currentHealthBar = healthBar;
    }
    public void takeDamage(int damage) 
    {
        if (!isImmune)
        { 
            StartCoroutine(loseHealthCoroutine(damage));
        }
    }

    private IEnumerator loseHealthCoroutine(int damage)
    {
        damageEvent?.Invoke();
        isImmune = true;
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            if (isPlayer) 
            {
                GameManager.Instance.isPlayerAlive = false;
            }
            if (isGameFinisher) 
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
