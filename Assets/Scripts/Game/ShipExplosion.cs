using UnityEngine;

public class ShipExplosion : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _partsOfShip;

    private void Start()
    {
        GameEventManager.StopGame += Destroy;
        foreach (var part in _partsOfShip)
        {
            part.AddExplosionForce(800f, transform.position, 20f);
        }

        Destroy(gameObject, 3f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameEventManager.StopGame -= Destroy;
    }
}
