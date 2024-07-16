using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UIManager;

public class UIOptions : MonoBehaviour, IGameUI
{
    private Action returnFunc;

    public void Init()
    { }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public void SetActive(bool active, Action action = null)
    {
        SetActive(active);
        if (action != null)
        {
            returnFunc = action;
        }
    }
    public GameUI GetUIType()
    {
        return GameUI.Options;
    }
    public void OnGoBack()
    {
        returnFunc?.Invoke();
    }
}