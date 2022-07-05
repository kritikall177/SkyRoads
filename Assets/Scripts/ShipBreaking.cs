using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipBreaking : MonoBehaviour
{
    [SerializeField] private GameObject _defaultShip;
    [SerializeField] private PartsOfShip _brokenShip;
    public static UnityAction CollisionAsteroid;

    private void Start()
    {
        CollisionAsteroid += OnShipBroken;
    }

    private void OnShipBroken()
    {
        Instantiate(_brokenShip, transform.position, Quaternion.identity);
        Destroy(_defaultShip);
    }
}
