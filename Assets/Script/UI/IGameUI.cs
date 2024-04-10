using static UIManager;

public interface IGameUI
{
    public void Init();
    public void SetActive(bool active);
    public GameUI GetUIType();
}