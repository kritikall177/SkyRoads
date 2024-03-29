using UnityEngine;
using UnityEngine.Events;

public class LerpAccelerationSystem : MonoBehaviour
{
    [SerializeField] private float durationLerp = 1f;
    [SerializeField] private SpeedLineEffect _speedLineEffect;
    [SerializeField] private ScoreSystem _scoreSystem;
    
    public float ElapsedTime { get; private set; }
    public float PercentageOfLerp { get; private set; }
    public bool IsLerp { get; private set; }

    public static UnityAction<bool, float> LerpAction;

    private void Start()
    {
        GameEventManager.LoseGame += () =>
        {
            StopLerp();
            enabled = false;
        };
        GameEventManager.RestartGame += () =>
        {
            StopLerp();
            enabled = true;
        };
        GameEventManager.StartGame += () => enabled = true;

    }

    private void Update()
    {
        PercentageOfLerp = ElapsedTime / durationLerp;
        AccelerationOnButton(Input.GetKey(KeyCode.Space));
    }

    private void AccelerationOnButton(bool buttonIsPressed)
    {
        if (buttonIsPressed)
        {
            if (PercentageOfLerp < 1)
            {
                _scoreSystem.IsAcceleration = true;
                IsLerp = true;
                ElapsedTime += Time.deltaTime;
                LerpAction?.Invoke(true, PercentageOfLerp);
            }
            else
            {
                _speedLineEffect.Play();
                IsLerp = false;
            }
        }
        else
        {
            if ((int)PercentageOfLerp == 1 && !IsLerp)
            {
                ElapsedTime = 0;
                IsLerp = true;
            }
            else if(PercentageOfLerp < 1 && IsLerp)
            {
                ElapsedTime += Time.deltaTime;
                LerpAction?.Invoke(false, PercentageOfLerp);
            }
            else
            {
                StopLerp();
            }
        }
    }

    private void StopLerp()
    {
        _scoreSystem.IsAcceleration = false;
        _speedLineEffect.Stop();
        IsLerp = false;
        ElapsedTime = 0;
    }
}
