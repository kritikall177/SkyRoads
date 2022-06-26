using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 15;
    [SerializeField] private float _tiltAngle = 45;
    
    private CharacterController _characterController;
    private Vector3 _movement;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        TurnOfTheShip(_movement);
    }

    private void TurnOfTheShip(Vector3 direction)
    {
        _characterController.Move(direction * (_speedRotation * Time.deltaTime));
        _characterController.transform.rotation = Quaternion.RotateTowards(_characterController.transform.rotation,
            Quaternion.Euler(0, 0, -_movement.x * _tiltAngle), _speedRotation);
    }
}