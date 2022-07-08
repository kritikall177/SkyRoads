using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ship;
    [SerializeField] private Vector3 _startPosition = new Vector3(0, 1.7f, 0);

    private void Start()
    {
        GameEventManager.RestartGame += CreateShip;
        CreateShip();
    }

    private void CreateShip()
    {
        Instantiate(_ship, _startPosition, Quaternion.identity);
    }
}
