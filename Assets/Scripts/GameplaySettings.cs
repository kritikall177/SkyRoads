using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySettings : Window
{
    [SerializeField] private Button _back;
    [SerializeField] private Slider _difficulty;
    [SerializeField] private Slider _turningSpeed;

    private void Start()
    {
        _difficulty.onValueChanged.AddListener(AsteroidGenerator.SetSpawnChance);
        _turningSpeed.onValueChanged.AddListener(ShipMovement.SetTurningSpeed);
        _difficulty.value = AsteroidGenerator.GetSpawnChance();
        _turningSpeed.value = ShipMovement.GetTurningSpeed();
        _back.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeCurrentWindowOn<WindowSettings>(gameObject);
        });
    }
}
