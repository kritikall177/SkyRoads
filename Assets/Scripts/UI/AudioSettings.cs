using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : Window
{
    [SerializeField] private Button _back;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _masterVolume;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _SFXVolume;

    private void Start()
    {
        _masterVolume.value = PlayerPrefs.GetFloat("MasterVolume", 1);
        _musicVolume.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        _SFXVolume.value = PlayerPrefs.GetFloat("EffectsVolume", 1);
        _masterVolume.onValueChanged.AddListener(volume => ChangeVolume(volume, "MasterVolume"));
        _musicVolume.onValueChanged.AddListener(volume => ChangeVolume(volume, "MusicVolume"));
        _SFXVolume.onValueChanged.AddListener(volume => ChangeVolume(volume, "EffectsVolume"));
        _back.onClick.AddListener(() => UIManager.Instance.ChangeCurrentWindowOn<WindowSettings>(gameObject));
    }

    private void ChangeVolume(float volume, string typeVolume)
    {
        _mixer.SetFloat(typeVolume, Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat(typeVolume, volume);
    }
}
