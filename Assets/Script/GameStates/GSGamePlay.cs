using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GSGamePlay : IGameState
{
    public void OnStateEnter()
    {
        InputManager.InputSystem.GamePlay.Enable();
        //UIManager.Instance.ShowUI = UIManager.GameUI.Gameplay;
    }

    public void OnStateExit()
    {
        InputManager.InputSystem.GamePlay.Disable();
    }

    public void OnStateUpdate()
    {
    }
}