using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ship;
    [SerializeField] private Vector3 _startPosition = new Vector3(0, 1.7f, 0);
    
    private GameObject _currentShip;

    private void Start()
    {
        GameEventManager.RestartGame += CreateShip;
        GameEventManager.StopGame += DestroyShip;
        GameEventManager.StartGame += CreateShip;
        CreateShip();
    }

    private void CreateShip()
    {
        _currentShip = Instantiate(_ship, _startPosition, Quaternion.identity);
    }

    private void DestroyShip()
    {
        if (_currentShip != null)
        {
            Destroy(_currentShip);
        }
    }
}
