using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePresets : MonoBehaviour
{
    [SerializeField] private ParticleSystem _engineParticleSystem;
    
    [SerializeField] private ParticleSystem.MinMaxGradient _defaultStartColor;
    [SerializeField] private ParticleSystem.MinMaxGradient _accelerationStartColor;

    [SerializeField] private float _defaultStartSpeed = 1f;
    [SerializeField] private float _accelerationStartSpeed = 0.7f;
    
    private ParticleSystem.MainModule _engineMainModule;

    private void Start()
    {
        LerpSystem.LerpAction += ChangeEngineParticle;
        _engineMainModule = _engineParticleSystem.main;
        _engineMainModule.startColor = _defaultStartColor;
        _engineMainModule.startSpeed = _defaultStartSpeed;
    }
    
    private void ChangeEngineParticle(bool isPressed, float percentageOfLerp)
    {
        if (isPressed)
        {
            _engineMainModule.startColor = _accelerationStartColor;
            _engineMainModule.startSpeed = Mathf.Lerp(_defaultStartSpeed, _accelerationStartSpeed, percentageOfLerp);
        }
        else
        {
            _engineMainModule.startColor = _defaultStartColor;
            _engineMainModule.startSpeed = Mathf.Lerp(_accelerationStartSpeed, _defaultStartSpeed, percentageOfLerp);
        }
    }
}
