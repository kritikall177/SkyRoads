using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int _defaultAddingScore = 1;
    [SerializeField] private int _asteroidScore = 5;
    
    public Text Text;

    public bool IsAcceleration;
    private int _score;

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
            _score += _defaultAddingScore * 2;
        }
        else
        {
            _score += _defaultAddingScore;
        }
        Text.text = $"Score: {_score}";
        StartCoroutine(AddPoint());
    }

    private void AddAsteroidPoint()
    {
        _score += _asteroidScore;
        Text.text = $"Score: {_score}";
    }
}
