using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    public int Score { get; private set; }
    public bool IsAcceleration;
    private int _defaultAddingScore = 1;
    private int _asteroidScore = 5;

    public static UnityAction AsteroidPassed;
    private void Start()
    {
        AsteroidPassed = AddAsteroidPoint;
        StartCoroutine(AddPoint());
    }

    private IEnumerator AddPoint()
    {
        yield return new WaitForSeconds(1);
        if (IsAcceleration)
        {
            Score += _defaultAddingScore * 2;
        }
        else
        {
            Score += _defaultAddingScore;
        }
        Debug.Log(Score);
        StartCoroutine(AddPoint());
    }

    public void AddAsteroidPoint()
    {
        Score += _asteroidScore;
    }
}
