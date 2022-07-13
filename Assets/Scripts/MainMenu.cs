using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Window
{
    [SerializeField] private Button _newGame;
    [SerializeField] private Button _setting;
    [SerializeField] private Button _quit;

    private void Start()
    {
        _newGame.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeCurrentWindowOn<GameUI>(gameObject);
            GameEventManager.StartGame.Invoke();
        });
        _setting.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeCurrentWindowOn<WindowSettings>(gameObject);
        });
        _quit.onClick.AddListener(Application.Quit);
    }
}