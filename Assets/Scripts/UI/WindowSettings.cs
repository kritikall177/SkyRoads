using UnityEngine;
using UnityEngine.UI;

public class WindowSettings : Window
{
    [SerializeField] private Button _gameplay;
    [SerializeField] private Button _video;
    [SerializeField] private Button _audio;
    [SerializeField] private Button _back;
    
    private void Start()
    {
        _gameplay.onClick.AddListener(() => UIManager.Instance.ChangeCurrentWindowOn<GameplaySettings>(gameObject));
        _video.onClick.AddListener(() => UIManager.Instance.ChangeCurrentWindowOn<VideoSettings>(gameObject));
        _audio.onClick.AddListener(() => UIManager.Instance.ChangeCurrentWindowOn<AudioSettings>(gameObject));
        _back.onClick.AddListener(() => UIManager.Instance.ChangeCurrentWindowOn<MainMenu>(gameObject));
    }
}
