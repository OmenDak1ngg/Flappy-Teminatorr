using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Count { get; private set; }

    public event Action ScoreChanged;

    private void Start()
    {
        Count = 0;
        ScoreChanged?.Invoke();
    }

    public void Increase()
    {
        Count += 1;
        ScoreChanged?.Invoke();
    }

    public void Restart()
    {
        Count = 0;
        ScoreChanged?.Invoke();
    }
}
