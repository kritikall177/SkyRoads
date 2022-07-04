using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] public Camera _camera;
    [SerializeField] public ParticleSystem _particleSystem;
    
    [SerializeField] private float maxFOV = 80f;
    [SerializeField] private float minFOV = 60f;
    
    private void Start()
    {
        //NewBehaviourScript.WhenLerp += CheckAccelerationOnKey;
        
        _particleSystem.Stop();
    }

    private void CheckAccelerationOnKey(bool isPressed, float percentageOfLerp)
    {
        if (isPressed)
        {
            if (_camera.fieldOfView < 80)
            {
                _camera.fieldOfView = Mathf.Lerp(minFOV, maxFOV, percentageOfLerp);
            }
            else if(!_particleSystem.isPlaying)
            {
                _particleSystem.Play();
            }
        }
        else
        {
            if (_camera.fieldOfView > 60)
            {
                _camera.fieldOfView = Mathf.Lerp(maxFOV, minFOV, percentageOfLerp);
            }
            else if(!_particleSystem.isStopped)
            {
                _particleSystem.Stop();
            }
        }
    }
}
