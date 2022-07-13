using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int _defaultAddingScore = 1;
    [SerializeField] private int _asteroidScore = 5;
    
    public static Text Text { get; set; }
    public static int OutScore { get; private set; }

    public bool IsAcceleration;
    private int _score;
    
    public static UnityAction AsteroidPassed;
    
    private void Start()
    {
        AsteroidPassed = AddAsteroidPoint;
        GameEventManager.StartGame += ResetScore;
        GameEventManager.LoseGame += StopAllCoroutines;
        GameEventManager.LoseGame += HighScoreCheck;
        GameEventManager.LoseGame += () => OutScore = _score;
        GameEventManager.RestartGame += ResetScore;
        GameEventManager.RestartGame += () => Text.text = $"Score: {_score}";
        StartCoroutine(AddPoint());
    }

    private void HighScoreCheck()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            if (_score > PlayerPrefs.GetInt("SaveScore"))
            {
                PlayerPrefs.SetInt("SaveScore", _score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SaveScore", _score);
        }
    }

    private void ResetScore()
    {
        _score = 0;
        IsAcceleration = false;
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

    public static int GetScore()
    {
        return OutScore; 
    }
}
