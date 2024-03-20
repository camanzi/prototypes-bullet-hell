using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GSGameOver : IGameState
{

    private float t;
    private const float loadingTime = 5;

    public void OnStateEnter()
    {
        InputManager.InputSystem.GamePlay.Enable();
        Time.timeScale = 0;
        t = 0;
    }

    public void OnStateExit()
    {
        Time.timeScale = 1;
    }

    public void OnStateUpdate()
    {
        t += Time.unscaledDeltaTime;
        if (t >= loadingTime) 
            GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
    }
}