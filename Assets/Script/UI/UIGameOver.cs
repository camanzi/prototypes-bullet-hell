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
        gameResult.text = GameManager.Instance.isPlayerAlive ? "Victory!" : "Lose!";
    }

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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) 
        {
            Destroy(player);
        }
        GameObject.Instantiate(GameManager.Instance.PF_Player, Vector3.zero, Quaternion.identity);
        GameManager.Instance.isPlayerAlive = true;
        GameStateManager.Instance.CurrentGameState = GameStateManager.GameStates.Gameplay;
    }
}