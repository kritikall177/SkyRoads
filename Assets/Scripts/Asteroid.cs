using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Взрыв");
        //Time.timeScale = 0;
    }
}
