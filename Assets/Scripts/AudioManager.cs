using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _UIMusic;
    [SerializeField] private AudioSource _gameMusic;
    [SerializeField] private AudioMixer _mixer;

    private void Start()
    {
        _mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume", 1));
        _mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 1));
        _mixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("EffectsVolume", 1));
        _UIMusic.Play();
        GameEventManager.StartGame += _gameMusic.Play;
        GameEventManager.StopGame += _gameMusic.Stop;
        GameEventManager.StartGame += _UIMusic.Stop;
        GameEventManager.StopGame += _UIMusic.Play;
    }
}
