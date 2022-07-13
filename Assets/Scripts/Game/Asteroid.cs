using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEventManager.LoseGame?.Invoke();
    }
}
