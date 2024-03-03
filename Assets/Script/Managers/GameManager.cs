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
            if (_instanse)
                return _instanse;
            _instanse = FindFirstObjectByType<GameManager>();
            if (!_instanse)
                Debug.LogError("Missing GameManager");
            return _instanse;
        }
    }

    private static GameManager _instanse;

    public PlayerMovement playerMovement;
}
