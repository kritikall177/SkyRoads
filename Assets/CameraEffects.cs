using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem.Stop();
    }

    public void NitroEffect(bool isActive)
    {
        switch (isActive)
        {
            case true when _particleSystem.isPlaying == false:
                _particleSystem.Play();
                _camera.fieldOfView += 20f;
                break;
            case false when _particleSystem.isStopped == false:
                _particleSystem.Stop();
                _camera.fieldOfView -= 20f;
                break;
        }
    }
}
