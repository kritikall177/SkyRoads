using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour
{
    public static UnityAction PauseGame;
    public static UnityAction ResumeGame;
    public static UnityAction LoseGame;
    public static UnityAction RestartGame;

    private void Start()
    {
        PauseGame += () => Time.timeScale = 0;
        ResumeGame += () => Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResumeGame.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame.Invoke();
        }
    }
}
