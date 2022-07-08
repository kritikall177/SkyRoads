using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _game;

    private void Start()
    {
        GameEventManager.StartGame += StartGame;
        GameEventManager.CloseGame += StopGame;
    }

    private void StartGame()
    {
        _game.SetActive(true);
    }

    private void StopGame()
    {
        _game.SetActive(false);
    }
}
