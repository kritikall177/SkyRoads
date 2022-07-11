using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Window> _listOfWindows;
    [SerializeField] private GameObject _ship;

    public static UIManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        Open<MainMenu>();
        Instantiate(_ship, transform);
    }

    private void Open<T>() where T : Window
    {
        var prefab = GetWindow<T>();
        Instantiate(prefab, transform);
    }

    private void Close(GameObject window)
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
}