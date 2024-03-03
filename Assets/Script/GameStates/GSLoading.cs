using UnityEngine;

public class GSLoading : IGameState
{

    private const float loadingTime = 2;
    private float t;
    public void OnStateEnter()
    {
        t = 0;
        //UIManager.Instance.ShowUI = UIManager.GameUI.Loading;
    }

    public void OnStateExit()
    {
    }

    public void OnStateUpdate()
    {
        t += Time.deltaTime;
        if (t >= loadingTime)
            GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
    }
}