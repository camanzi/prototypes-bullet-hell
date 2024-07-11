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
    public GameUI GetUIType()
    {
        return GameUI.MainMenu;
    }
    public void OnPlayClick()
    {
        GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
    }
    public void OnOptionClick() 
    {
        UIManager.Instance.ShowUI((new List<GameUI>() { GameUI.Options }));
    }
    public void OnExitClick()
    {
        Application.Quit();
    }
}