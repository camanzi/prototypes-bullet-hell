using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UIManager;

public class GSLoading : IGameState
{
    float t = 0;

    public void OnStateEnter()
    {
        UIManager.Instance.ShowUI(new List<GameUI>() { GameUI.Loading });
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void OnStateExit()
    {}

    public void OnStateUpdate()
    {
        t += Time.unscaledDeltaTime;
        if (t > 10)
        {
            GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
        }
    }
}