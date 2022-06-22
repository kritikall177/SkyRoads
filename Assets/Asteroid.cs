using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    
    private void OnTriggerEnter(Collider _collider)
    {
        Debug.Log("Взрыв");
        Time.timeScale = 0;
    }
}
