using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UIManager;

public class GSGamePlay : IGameState
{
    public void OnStateEnter()
    {
        Time.timeScale = 1.0f;
        InputManager.InputSystem.GamePlay.Enable();
        UIManager.Instance.ShowUI(new List<GameUI>() { GameUI.Gameplay });
    }

    public void OnStateExit()
    {
        InputManager.InputSystem.GamePlay.Disable();
    }

    public void OnStateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Pause;
        }

    }
}