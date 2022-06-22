using DG.Tweening;
using UnityEngine;

public class AsteroidLevitation : MonoBehaviour
{
    [SerializeField] private Transform positionAsteroid;
    private float _durationRotate = 3f;
    private float _durationMove = 1f;
    private Vector3 _amplitude = new Vector3(0, 0.3f, 0);
    
    private void Start()
    {
        positionAsteroid.DORotate(new Vector3(0, 360, 0), _durationRotate, RotateMode.FastBeyond360).SetLoops(-1)
            .SetEase(Ease.Linear);
        positionAsteroid.DOLocalMove(positionAsteroid.localPosition + _amplitude, _durationMove)
            .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
