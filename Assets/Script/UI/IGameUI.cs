using System;
using static UIManager;

public interface IGameUI
{
    public void Init();
    public void SetActive(bool active);

    public void SetActive(bool active, Action action = null);
    public GameUI GetUIType();
}