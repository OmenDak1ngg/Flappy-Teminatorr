using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    [SerializeField] private Terminator _terminator;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private RestartButton _restartButton;

    private ISpawner[] _spawners;

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

    private void Start()
    {
        var all = FindObjectsOfType<MonoBehaviour>();
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        _endGameScreen.ShowEndGameScreen();
    }

    private void StartGame()
    {
        GameRestarted?.Invoke();
        _terminator.OnRevive();
        _inputReader.SetInputEnabled(true);
        Time.timeScale = 1f;
        _endGameScreen.HideEndGameScreen();

        foreach(var spawner in _spawners)
        {
            spawner.ReleaseAllObjects();
        }
    }
}
