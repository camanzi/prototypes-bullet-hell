using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GSLoading : IGameState
{
    public void OnStateEnter()
    {
        //UIManager.Instance.ShowUI = UIManager.GameUI.Loading;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
    }

    public void OnStateExit()
    {}

    public void OnStateUpdate()
    {}
}