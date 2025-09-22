using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Terminator _terminator;
    [SerializeField] private EndGameScreen _endGameScreen;

    [SerializeField] private RestartButton _restartButton;

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
        _terminator.OnRevive();
        Time.timeScale = 1f;
        _endGameScreen.HideEndGameScreen();
    }
}
