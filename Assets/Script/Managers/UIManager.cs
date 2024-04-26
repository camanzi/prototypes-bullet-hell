using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance
    {
        get
        {
            if (_instanse)
                return _instanse;
            _instanse = FindFirstObjectByType<UIManager>();
            if (!_instanse)
                Debug.LogError("Missing UIManager");
            return _instanse;
        }
    }
    private static UIManager _instanse;

    #region BASIC UI STATES LOADING AND UPDATE
    public enum GameUI
    {
        NONE,
        Loading,
        Teardown,
        MainMenu,
        Gameplay,
        GameOver,
    }
    private IGameUI currentUI;
    private Dictionary<GameUI, IGameUI> registeredUIs = new Dictionary<GameUI, IGameUI>();

    public Transform UiContainer;
    private void Awake()
    {
        foreach (IGameUI enumeratedUi in UiContainer.GetComponentsInChildren<IGameUI>(true))
        {
            RegisterUI(enumeratedUi.GetUIType(), enumeratedUi);
        }
        ShowUI(new List<GameUI>() { GameUI.NONE });
    }

    public void RegisterUI(GameUI UItype, IGameUI UIToRegister)
    {
        UIToRegister.Init();
        registeredUIs.Add(UItype, UIToRegister);

    }

    public void ShowUI(List<GameUI> UITypes)
    {
        foreach (KeyValuePair<GameUI, IGameUI> keyValue in registeredUIs)
        {
            keyValue.Value.SetActive(UITypes.Contains(keyValue.Key));
        }
    }
    #endregion
}
