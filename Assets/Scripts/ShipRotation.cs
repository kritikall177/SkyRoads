using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShipRotation : MonoBehaviour
{
    [SerializeField] private Transform positionAsteroid;
    
    private float _durationRotate = 10f;
    
    private void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        positionAsteroid.DORotate(new Vector3(10, 540, 0), _durationRotate, RotateMode.FastBeyond360).SetLoops(-1)
            .SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
