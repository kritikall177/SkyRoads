using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : Window
{
    [SerializeField] private Button _back;
    [SerializeField] private Slider _shadowDistance;
    [SerializeField] private Toggle _antiAliasingToggle;

    private void Start()
    {
        _shadowDistance.onValueChanged.AddListener(value => QualitySettings.shadowDistance = Mathf.Lerp(0, 140, value));
        _shadowDistance.value = QualitySettings.shadowDistance / 140;
        _antiAliasingToggle.onValueChanged.AddListener(isActive => QualitySettings.antiAliasing = isActive ? 2 : 0);
        _antiAliasingToggle.isOn = QualitySettings.antiAliasing > 0;
        _back.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeCurrentWindowOn<WindowSettings>(gameObject);
        });
    }
}
