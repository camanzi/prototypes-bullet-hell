using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GSPause : IGameState
{
    public void OnStateEnter()
    {
        Time.timeScale = 0f;
        InputManager.InputSystem.GamePlay.Disable();
        UIManager.Instance.ShowUI((new List<UIManager.GameUI>() { UIManager.GameUI.Pause }));
    }

    public void OnStateExit()
    {}

    public void OnStateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
        }
    }
}