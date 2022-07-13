using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        ScoreSystem.AsteroidPassed?.Invoke();
    }
}
