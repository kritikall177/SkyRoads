using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _game;

    private void Start()
    {
        GameEventManager.StartGame += StartGame;
        GameEventManager.StopGame += StopGame;
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
