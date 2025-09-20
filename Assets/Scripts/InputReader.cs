using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly KeyCode KeyCodeBoost = KeyCode.Space;
    private readonly KeyCode KeyCodeShoot = KeyCode.F;

    public event Action Boosted;
    public event Action Shooted;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCodeBoost))
            Boosted?.Invoke();

        if (Input.GetKeyDown(KeyCodeShoot))
        {
            Shooted?.Invoke(); 
            Debug.Log("pressed shoot button");
        }
    }
}
