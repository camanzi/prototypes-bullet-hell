using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UIManager;

public class UIMainMenu: MonoBehaviour, IGameUI
{
    public void Init()
    { }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public void SetActive(bool active, Action action = null)
    {
        SetActive(active);
    }
    public GameUI GetUIType()
    {
        return GameUI.MainMenu;
    }
    public void OnPlayClick()
    {
        GameManager.Instance.ResetScene();
    }
    public void OnOptionClick() 
    {
        UIManager.Instance.ShowUI((new List<GameUI>() { GameUI.Options }), true);
    }
    public void OnExitClick()
    {
        Application.Quit();
    }
}