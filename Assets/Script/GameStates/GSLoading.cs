using UnityEngine;

public class GSLoading : IGameState
{
    private float t;
    private const float loadingTime = 5;
    public void OnStateEnter()
    {
        Time.timeScale = 0;
        t = 0;
        //UIManager.Instance.ShowUI = UIManager.GameUI.Loading;
    }

    public void OnStateExit()
    {
        Time.timeScale = 1;
    }

    public void OnStateUpdate()
    {
        t += Time.unscaledDeltaTime;
        if (t >= loadingTime)
            GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
    }
}