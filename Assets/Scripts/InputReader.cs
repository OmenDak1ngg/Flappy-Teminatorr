using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly KeyCode KeyCodeBoost = KeyCode.Space;
    private readonly KeyCode KeyCodeShoot = KeyCode.F;

    private bool _isInputEnabled;

    public event Action Boosted;
    public event Action Shooted;

    private void Update()
    {
        if(_isInputEnabled == false)
            return;

        if (Input.GetKeyDown(KeyCodeBoost))
            Boosted?.Invoke();

        if (Input.GetKeyDown(KeyCodeShoot))
        {
            Shooted?.Invoke(); 
        }
    }

    public void SetInputEnabled(bool enabled)
    {
        _isInputEnabled = enabled;
    }
}
