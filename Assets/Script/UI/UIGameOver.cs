using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UIManager;

public class UIGameOver : MonoBehaviour, IGameUI
{
    public void Init()
    { }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public GameUI GetUIType()
    {
        return GameUI.GameOver;
    }

    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject.Instantiate(GameManager.Instance.PF_Player, Vector3.zero, Quaternion.identity);
        GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
    }
}