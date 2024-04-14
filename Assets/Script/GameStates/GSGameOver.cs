using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;
public class GSGameOver : IGameState
{
    public void OnStateEnter()
    {
        InputManager.InputSystem.GamePlay.Disable();
        UIManager.Instance.ShowUI(new List<GameUI>() { GameUI.GameOver });
    }

    public void OnStateExit()
    {}

    public void OnStateUpdate()
    {}
}