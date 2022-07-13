using UnityEngine;

public class AddScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        ScoreSystem.AsteroidPassed?.Invoke();
    }
}
