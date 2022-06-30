using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LerpSystem : MonoBehaviour
{
    [SerializeField] private float durationLerp = 1f;
    [SerializeField] private SpeedLineEffect _speedLineEffect;
    public float ElapsedTime { get; private set; }
    public float PercentageOfLerp { get; private set; }
    public bool IsLerp { get; private set; }

    public static UnityAction<bool, float> LerpAction;

    private void Update()
    {
        PercentageOfLerp = ElapsedTime / durationLerp;
        EffectOnButton(Input.GetKey(KeyCode.Space));
    }

    private void EffectOnButton(bool buttonIsPressed)
    {
        if (buttonIsPressed)
        {
            if (PercentageOfLerp < 1)
            {
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
                _speedLineEffect.Stop();
                IsLerp = false;
                ElapsedTime = 0;
            }
        }
    }
}
