using UnityEngine;
using UnityEngine.UI;

public class GameUI : Window
{
    [SerializeField] private Button _pause;
    [SerializeField] private Text _text;

    private void Start()
    {
        ScoreSystem.Text = _text;
        GameEventManager.StopGame += DestroyGameUI;
        GameEventManager.PauseTime += DisableButton;
        GameEventManager.ResumeTime += EnableButton;
        GameEventManager.RestartGame += EnableButton;
        GameEventManager.LoseGame += DisableButton;
        GameEventManager.LoseGame += OpenLoseMenu;
        _pause.onClick.AddListener(() => UIManager.Instance.Open<PauseMenu>());
    }

    private void OpenLoseMenu()
    {
        UIManager.Instance.Open<LosingMenu>();
    }

    private void DestroyGameUI()
    {
        Destroy(gameObject);
    }

    private void DisableButton()
    {
        _pause.enabled = false;
    }

    private void EnableButton()
    {
        _pause.enabled = true;
    }

    private void OnDestroy()
    {
        GameEventManager.StopGame -= DestroyGameUI;
        GameEventManager.PauseTime -= DisableButton;
        GameEventManager.ResumeTime -= EnableButton;
        GameEventManager.RestartGame -= EnableButton;
        GameEventManager.LoseGame -= DisableButton;
        GameEventManager.LoseGame -= OpenLoseMenu;
    }
}