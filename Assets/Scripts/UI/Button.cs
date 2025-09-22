using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action Clicked;

    private void Awake()
    {
        Debug.Log("active");
    }

    public void OnClicked()
    {
        Debug.Log("cliecked");
        Clicked?.Invoke();
    }
}
