using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GSTeardown : IGameState
{
    public void OnStateEnter()
    {
        Application.Quit();
    }

    public void OnStateExit()
    {}

    public void OnStateUpdate()
    {}
}