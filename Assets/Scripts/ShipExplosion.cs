using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipExplosion : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _partsOfShip;

    private void Start()
    {
        foreach (var part in _partsOfShip)
        {
            part.AddExplosionForce(800f, transform.position, 20f);
        }

        Destroy(gameObject, 3f);
    }
}
