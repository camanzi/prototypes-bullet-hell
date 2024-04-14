using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class GSGamePlay : IGameState
{
    public void OnStateEnter()
    {
        InputManager.InputSystem.GamePlay.Enable();
        UIManager.Instance.ShowUI(new List<GameUI>() { GameUI.Gameplay });
    }

    public void OnStateExit()
    {
        InputManager.InputSystem.GamePlay.Disable();
    }

    public void OnStateUpdate()
    {}
}