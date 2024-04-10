using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UIManager;

public class UIGameplay : MonoBehaviour, IGameUI
{

    public TextMeshProUGUI textField;
    public void Init()
    { }

    private void Update()
    {
        textField.text = GameManager.Instance.playerHealthController.currentHealth.ToString();
    }

    public void SetActive(bool active) 
    {
        gameObject.SetActive(active);
    }
    public GameUI GetUIType() 
    {
        return GameUI.Gameplay;
    }
}