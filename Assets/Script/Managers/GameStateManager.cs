using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance
    {
        get
        {
            if (_instanse)
                return _instanse;
            _instanse = FindFirstObjectByType<GameStateManager>();
            if (!_instanse)
                Debug.LogError("Missing GameStateManager");
            return _instanse;
        }
    }
    private static GameStateManager _instanse;

    [SerializeReference] private GameStates startinState = GameStates.Loading;


    #region BASIC GAME STATES LOADING AND UPDATE
    public enum GameStates
    {
        Loading,
        Teardown,
        Gameplay,
        GameOver,
    }
    private readonly Dictionary<GameStates, IGameState> registeredGameStates = new();
    public void RegisterAllStates()
    {
        RegisterState(GameStates.Loading, new GSLoading());
        RegisterState(GameStates.Teardown, new GSTeardown());
        RegisterState(GameStates.Gameplay, new GSGamePlay());
        RegisterState(GameStates.GameOver, new GSGameOver());
    }
    private void RegisterState(GameStates gstate, IGameState state)
    {
        registeredGameStates.Add(gstate, state);
    }

    [SerializeField] private GameStates _currentGameState;

    public GameStates CurrentGameState
    {
        get
        {
            return _currentGameState;
        }
        set
        {
            CurrentIGameState?.OnStateExit();
            _currentGameState = value;
            CurrentIGameState.OnStateEnter();
        }
    }
    private IGameState CurrentIGameState
    {
        get
        {
            return registeredGameStates[_currentGameState];
        }
    }

    private void Start()
    {
        RegisterAllStates();
        CurrentGameState = startinState;
    }

    private void Update()
    {
        CurrentIGameState?.OnStateUpdate();
    }
    #endregion
}
