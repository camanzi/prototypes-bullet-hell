using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UIManager;

public class UILoading : MonoBehaviour, IGameUI
{
    public void Init()
    { }

    private void Update()
    {}

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public GameUI GetUIType()
    {
        return GameUI.Loading;
    }
}