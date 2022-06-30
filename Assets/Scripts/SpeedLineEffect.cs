using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLineEffect : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    private void Start()
    {
        Stop();
    }

    public void Stop()
    {
        if (ParticleSystem.isPlaying)
        {
            ParticleSystem.Stop();
        }
    }
    
    public void Play()
    {
        if (ParticleSystem.isStopped)
        {
            ParticleSystem.Play();
        }
    }
}
