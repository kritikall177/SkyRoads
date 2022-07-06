using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private AsteroidGenerator _asteroidGenerator;

    private void OnTriggerEnter(Collider other)
    {
        GameEventManager.LoseGame?.Invoke();
    }
}
