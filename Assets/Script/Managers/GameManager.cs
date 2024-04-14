using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [HideInInspector]
    public HealthController playerHealthController { get { return _playerHealthController; } }

    private HealthController _playerHealthController;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").TryGetComponent<HealthController>(out _playerHealthController);
        if (!_playerHealthController) { throw new System.Exception("No Player health controller found"); }
    }

    
}
