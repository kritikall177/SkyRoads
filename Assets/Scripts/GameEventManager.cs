using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour
{
    public static UnityAction PauseTime;
    public static UnityAction ResumeTime;
    public static UnityAction LoseGame;
    public static UnityAction RestartGame;
    public static UnityAction StartGame;
    public static UnityAction StopGame;

    private void Start()
    {
        PauseTime += () => Time.timeScale = 0;
        ResumeTime += () => Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseTime.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResumeTime.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame.Invoke();
        }
    }

    public void OnClick()
    {
        StartGame?.Invoke();
    }
    
    public void OnClose()
    {
        StopGame?.Invoke();
    }
}
