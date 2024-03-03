using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GSGamePlay : IGameState
{
    public void OnStateEnter()
    {
        InputManager.InputSystem.GamePlay.Enable();
        Cursor.visible = false;
        //UIManager.Instance.ShowUI = UIManager.GameUI.Gameplay;
    }

    public void OnStateExit()
    {
        Cursor.visible = true;
        InputManager.InputSystem.GamePlay.Disable();
    }

    public void OnStateUpdate()
    {
    }
}