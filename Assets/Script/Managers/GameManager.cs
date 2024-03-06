using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

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
}
