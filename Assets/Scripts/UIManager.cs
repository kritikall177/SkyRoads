using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Window> _listOfWindows;
    [SerializeField] private GameObject _ship;
    [SerializeField] private GameObject _highScore;
    public static UIManager Instance { get; private set; }

    private void Start()
    {
        GameEventManager.StopGame += CreateShip;
        GameEventManager.StopGame += CreateHighScoreWindow;
        CreateShip();
        CreateHighScoreWindow();
        Instance = this;
        Open<MainMenu>();
    }

    public void Open<T>() where T : Window
    {
        var prefab = GetWindow<T>();
        Instantiate(prefab, transform);
    }

    public void Close(GameObject window)
    {
        Destroy(window);
    }

    public void ChangeCurrentWindowOn<T>(GameObject windowToClose)
        where T : Window
    {
        Close(windowToClose);
        Open<T>();
    }

    private T GetWindow<T>() where T : Window
    {
        foreach (var window in _listOfWindows)
        {
            if (window is T resultWindow)
            {
                return resultWindow;
            }
        }

        return null;
    }
    
    public void CreateShip()
    {
        Instantiate(_ship, transform);
        
    }
    
    public void CreateHighScoreWindow()
    {
        Instantiate(_highScore, transform);
        
    }
}