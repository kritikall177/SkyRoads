using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] public Camera _camera;
    [SerializeField] private float maxFieldOfView = 80f;
    [SerializeField] private float minFieldOfView = 60f;

    private void Start()
    {
        LerpSystem.LerpAction += ChangeCameraFieldOfView;
    }

    private void ChangeCameraFieldOfView(bool isPressed, float percentageOfLerp)
    {
        if (isPressed)
        {
            _camera.fieldOfView = Mathf.Lerp(minFieldOfView, maxFieldOfView, percentageOfLerp);
        }
        else
        {
            _camera.fieldOfView = Mathf.Lerp(maxFieldOfView, minFieldOfView, percentageOfLerp);
        }
    }
}
