using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{ 
    [SerializeField] private float _tiltAngle = 45;
    [SerializeField] private CharacterController _characterController;
    
    public static float _turningSpeed { get; private set; } = 15;
    
    private Vector3 _movement;
    private Transform _position;

    private void Start()
    {
        _position = transform;
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
        _characterController.Move(direction * (_turningSpeed * Time.deltaTime));
        _characterController.transform.rotation = Quaternion.RotateTowards(_characterController.transform.rotation,
            Quaternion.Euler(0, 0, -_movement.x * _tiltAngle), _turningSpeed);
    }
    
    public static void SetTurningSpeed(float value)
    {
        _turningSpeed = (int)Mathf.Lerp(15, 100, value);
    }
    
    public static float GetTurningSpeed()
    {
        return _turningSpeed / 75;
    }
}