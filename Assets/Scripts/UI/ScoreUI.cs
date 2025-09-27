using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMeshPro;

    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += UpdateScore; 
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= UpdateScore;
    }

    private void UpdateScore()
    {
        _textMeshPro.text = _scoreCounter.Count.ToString();
    }
}
