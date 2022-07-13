using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLineEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        GameEventManager.LoseGame += Stop;
        GameEventManager.StopGame += Stop;
        Stop();
    }

    public void Stop()
    {
        if (_particleSystem.isPlaying)
        {
            _particleSystem.Stop();
        }
    }
    
    public void Play()
    {
        if (_particleSystem.isStopped)
        {
            _particleSystem.Play();
        }
    }
}
