using DG.Tweening;
using UnityEngine;

public class ShipUI : MonoBehaviour
{
    [SerializeField] private Transform positionAsteroid;
    
    private float _durationRotate = 10f;

    private void Start()
    {
        GameEventManager.StartGame += Destroy;
        StartAnimation();
    }

    private void StartAnimation()
    {
        positionAsteroid.DORotate(new Vector3(10, 540, 0), _durationRotate, RotateMode.FastBeyond360).SetLoops(-1)
            .SetEase(Ease.Linear);
    }
    
    private void Destroy()
    {
        UIManager.Instance.Close(gameObject);
    }

    private void OnDestroy()
    {
        GameEventManager.StartGame -= Destroy;
        transform.DOKill();
    }
}
