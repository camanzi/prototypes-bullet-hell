using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class UIGameplay : MonoBehaviour, IGameUI
{

    [SerializeField] private float damageTakenShowTime;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Transform heartContainer;
    [SerializeField] private GameObject onDamageImage;
    [SerializeField] private GameObject bossBar;
    [SerializeField] private GameObject bossHealthBar;

    private Coroutine showingDamageTakenCoroutine;

    public void Init()
    {}
    private void OnEnable()
    {
        GameManager.Instance.playerHealthController.damageEvent += ShowDamageTaken;
        GameManager.Instance.startBossFightEvent += ShowBossBar;
    }
    private void OnDisable()
    {
        GameManager.Instance.playerHealthController.damageEvent -= ShowDamageTaken;
        GameManager.Instance.startBossFightEvent -= ShowBossBar;
    }
    private void Update()
    {
        GenerateHeart();
    }

    public void SetActive(bool active) 
    {
        gameObject.SetActive(active);
    }
    public GameUI GetUIType() 
    {
        return GameUI.Gameplay;
    }
    private void ClearContainer(Transform container) 
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }
    private void GenerateHeart() 
    {
        ClearContainer(heartContainer);
        CreateHeart();
    }
    private void CreateHeart() 
    {
        int heart = GameManager.Instance.playerHealthController.currentHealth;
        for (int i = 0; i < heart; i++) 
        {
            Instantiate(heartPrefab, heartContainer);
        }
    }
    private void ShowDamageTaken() 
    {
        if (showingDamageTakenCoroutine != null) 
        {
            StopCoroutine(showingDamageTakenCoroutine);
        }
        showingDamageTakenCoroutine = StartCoroutine(nameof(ShowDamageTakenCoroutine));
    }
    private IEnumerator ShowDamageTakenCoroutine() 
    {
        onDamageImage.SetActive(true);
        yield return new WaitForSeconds(damageTakenShowTime);
        onDamageImage.SetActive(false);
    }
    private void ShowBossBar(HealthController bossHealthController) 
    {
        bossBar.SetActive(true);
        bossHealthController.SetCurrentHealthBar(bossHealthBar.GetComponent<Image>());
    }
}