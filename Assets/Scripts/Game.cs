using UnityEngine;
using System;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    [SerializeField] private Terminator _terminator;
    [SerializeField] private List<BaseSpawner> _spawners;
    [SerializeField] private ScoreCounter _scoreCounter;

    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private RestartButton _restartButton;

    public event Action GameRestarted;

    private void OnEnable()
    {
        _terminator.ReachedRemoveZone += EndGame;
        _restartButton.Clicked += StartGame;
    }

    private void OnDisable()
    {
        _terminator.ReachedRemoveZone -= EndGame;
        _restartButton.Clicked -= StartGame;
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        _endGameScreen.ShowEndGameScreen();
    }

    private void StartGame()
    {
        GameRestarted?.Invoke();
     
        _scoreCounter.Restart();
        _terminator.OnRevive();
        _inputReader.SetInputEnabled(true);
        Time.timeScale = 1f;
        _endGameScreen.HideEndGameScreen();

        foreach(BaseSpawner spawner in _spawners)
        {
            spawner.ReleaseAllObjects();
        }
    }
}
