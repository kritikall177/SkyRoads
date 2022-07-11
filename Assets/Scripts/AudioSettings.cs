using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : Window
{
    [SerializeField] private Button _back;

    private void Start()
    {
        _back.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeCurrentWindowOn<WindowSettings>(gameObject);
        });
    }
}
