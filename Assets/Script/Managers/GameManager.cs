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

    [HideInInspector]
    public bool isPlayerAlive = true;

    [HideInInspector]
    public HealthController playerHealthController { get { return _playerHealthController; } }

    private HealthController _playerHealthController;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += newSceneLoaded;
    }

    private void newSceneLoaded(Scene current, LoadSceneMode mode)
    {
        GameObject.FindGameObjectWithTag("Player").TryGetComponent<HealthController>(out _playerHealthController);
        if (!_playerHealthController) { throw new System.Exception("No Player health controller found"); }
    }

}
