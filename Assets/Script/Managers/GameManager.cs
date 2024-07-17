using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (_instance)
                return _instance;
            _instance = FindFirstObjectByType<GameManager>();
            if (!_instance)
                Debug.LogError("Missing GameManager");
            return _instance;
        }
    }

    private static GameManager _instance;

    public GameObject PF_Player;

    [HideInInspector] public bool isPlayerAlive = true;
    [HideInInspector] public HealthController playerHealthController { get { return _playerHealthController; } }
    private HealthController _playerHealthController;

    public event Action<HealthController> startBossFightEvent;
    public event Action stopBossFightEvent;

    public HealthController bossHealthController { get { return _bossHealthController; } }
    private HealthController _bossHealthController;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("GameScene");
        SetBossHealthController(null);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Destroy(player);
        }
        GameObject playerInstance = Instantiate(PF_Player, Vector3.zero, Quaternion.identity);
        playerInstance.TryGetComponent<HealthController>(out _playerHealthController);
        isPlayerAlive = true;
        GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
    }
    public void SetBossHealthController(HealthController bossHealthController) 
    {
        _bossHealthController = bossHealthController;
        if (bossHealthController)
        {
            startBossFightEvent?.Invoke(bossHealthController);
        }
        else {
            stopBossFightEvent?.Invoke();
        }
    }
}
