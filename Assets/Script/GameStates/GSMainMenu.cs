using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class GSMainMenu : IGameState
{
    public void OnStateEnter()
    {
        InputManager.InputSystem.GamePlay.Disable();
        UIManager.Instance.ShowUI(new List<GameUI>() { GameUI.MainMenu });
    }

    public void OnStateExit()
    {}

    public void OnStateUpdate()
    {}
}