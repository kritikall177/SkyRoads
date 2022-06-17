using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("afafas");
    }
}
