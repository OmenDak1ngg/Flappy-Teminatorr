using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionHandler : MonoBehaviour
{
    public event Action<Iinteractable> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered");

        if (collision.TryGetComponent<Iinteractable>(out Iinteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }
}
