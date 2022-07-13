using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : Window
{
    [SerializeField] private Button _resume;
    [SerializeField] private Button _exit;

    private void Start()
    {
        GameEventManager.PauseTime.Invoke();
        _resume.onClick.AddListener(() =>
        {
            GameEventManager.ResumeTime.Invoke();
            UIManager.Instance.Close(gameObject);
        });
        _exit.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeCurrentWindowOn<MainMenu>(gameObject);
            GameEventManager.StopGame.Invoke();
            GameEventManager.ResumeTime.Invoke();
        });
    }
}
