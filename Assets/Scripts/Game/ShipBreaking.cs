using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipBreaking : MonoBehaviour
{
    [SerializeField] private GameObject _defaultShip;
    [SerializeField] private ShipExplosion brokenShipExplosion;

    private void Start()
    {
        GameEventManager.LoseGame += OnShipBroken;
    }

    private void OnShipBroken()
    {
        Instantiate(brokenShipExplosion, transform.position, Quaternion.identity);
        Destroy(_defaultShip);
    }

    private void DestroyShip()
    {
        Destroy(_defaultShip);
    }
    
    private void OnDestroy()
    {
        GameEventManager.LoseGame -= OnShipBroken;
    }
}
