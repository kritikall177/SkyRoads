using System.Collections;
using UnityEngine;

public class SpaceDustEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    
    [SerializeField] private float _defaultSpeed = 100f;
    [SerializeField] private float _maxSpeed = 500f;
    [SerializeField] private float _defaultAccelerationSpeed = 5f;
    
    private ParticleSystem.MainModule _engineMainModule;
    private float _speed;

    private void Start()
    {
        _engineMainModule = _particleSystem.main;
        GameEventManager.LoseGame += Pause;
        GameEventManager.RestartGame += StartPlay;
        StartPlay();
    }

    private IEnumerator AddSpeed()
    {
        yield return new WaitForSeconds(1);
        if (_speed < _maxSpeed)
        {
            _speed += _defaultAccelerationSpeed;
            _engineMainModule.startSpeed = _speed;
            StartCoroutine(AddSpeed());
        }
    }

    private void Pause()
    {
        if (_particleSystem.isPlaying)
        {
            _particleSystem.Pause();
            StopAllCoroutines();
        }
    }

    private void StartPlay()
    {
        _speed = _defaultSpeed;
        StartCoroutine(AddSpeed());
        _particleSystem.Play();
    }
}
