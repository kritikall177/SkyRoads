using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 15;

    public float tiltAngle = 45;
    
    private CharacterController ch;

    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector3 direction)
    {
        ch.Move(direction * speed * Time.deltaTime);
        ch.transform.rotation = Quaternion.Euler(0, 0, -movement.x * tiltAngle);
    }
}