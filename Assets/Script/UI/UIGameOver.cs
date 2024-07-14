using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UIManager;

public class UIGameOver : MonoBehaviour, IGameUI
{
    [SerializeField]
    private TextMeshProUGUI gameResult;
    public void Init()
    { }

    private void OnEnable()
    {
        gameResult.text = GameManager.Instance.isPlayerAlive ? "Escaped!" : "You Died";
        gameResult.color = GameManager.Instance.isPlayerAlive ? new Color(191, 185, 39) : new Color(99, 00, 00);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public GameUI GetUIType()
    {
        return GameUI.GameOver;
    }
    public void OnRestartClick()
    {
        GameManager.Instance.ResetScene();
    }
    public void OnExitClick()
    {
        UIManager.Instance.ShowUI((new List<GameUI>() { GameUI.MainMenu }));
    }
}