using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosingMenu : Window
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;

    private void Start()
    {
        _scoreText.text = $"Your score:{ScoreSystem.GetScore()}";
        _restart.onClick.AddListener(() =>
        {
            GameEventManager.RestartGame.Invoke();
            UIManager.Instance.Close(gameObject);
        });
        _exit.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeCurrentWindowOn<MainMenu>(gameObject);
            GameEventManager.StopGame.Invoke();
        });
    }
}
