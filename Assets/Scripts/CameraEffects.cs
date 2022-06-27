using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] public Camera _camera;
    [SerializeField] public ParticleSystem _particleSystem;
    [SerializeField] private float durationLerp = 1f;
    [SerializeField] private float maxFOV = 80f;
    [SerializeField] private float minFOV = 60f;
    
    public float ElapsedTime { get; private set; }
    public float PercentageOfLerp { get; private set; }
    public bool IsLerp { get; private set; }
    
    private void Start()
    {
        _particleSystem.Stop();
    }

    private void Update()
    {
        PercentageOfLerp = ElapsedTime / durationLerp;
        CheckAccelerationOnKey(Input.GetKey(KeyCode.Space));
    }

    private void CheckAccelerationOnKey(bool isPressed)
    {
        if (isPressed)
        {
            if (_camera.fieldOfView < 80)
            {
                IsLerp = true;
                ElapsedTime += Time.deltaTime;
                _camera.fieldOfView = Mathf.Lerp(minFOV, maxFOV, PercentageOfLerp);
            }
            else if(!_particleSystem.isPlaying)
            {
                _particleSystem.Play();
                ElapsedTime = 0;
                IsLerp = false;
            }
        }
        else
        {
            if (_camera.fieldOfView > 60)
            {
                IsLerp = true;
                ElapsedTime += Time.deltaTime;
                _camera.fieldOfView = Mathf.Lerp(maxFOV, minFOV, PercentageOfLerp);
            }
            else if(!_particleSystem.isStopped)
            {
                _particleSystem.Stop();
                ElapsedTime = 0;
                IsLerp = false;
            }
        }
    }
}
