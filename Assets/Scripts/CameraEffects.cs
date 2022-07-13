using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private float maxFieldOfView = 80f;
    [SerializeField] private float minFieldOfView = 60f;
    [SerializeField] private Vector3 _rotationToGame = new Vector3(10, 0, 0);
    [SerializeField] private Vector3 _rotationToMenu = new Vector3(-30, 0, 0);

    private void Start()
    {
        GameEventManager.StartGame += () => transform.rotation = Quaternion.Euler(_rotationToGame);
        GameEventManager.StartGame += () => _camera.fieldOfView = minFieldOfView;
        GameEventManager.StopGame += () => transform.rotation = Quaternion.Euler(_rotationToMenu);
        GameEventManager.RestartGame += () => _camera.fieldOfView = minFieldOfView;
        LerpAccelerationSystem.LerpAction += ChangeCameraFieldOfView;
    }

    private void ChangeCameraFieldOfView(bool isPressed, float percentageOfLerp)
    {
        if (isPressed && Time.timeScale != 0)
        {
            _camera.fieldOfView = Mathf.Lerp(minFieldOfView, maxFieldOfView, percentageOfLerp);
        }
        else
        {
            _camera.fieldOfView = Mathf.Lerp(maxFieldOfView, minFieldOfView, percentageOfLerp);
        }
    }
}
