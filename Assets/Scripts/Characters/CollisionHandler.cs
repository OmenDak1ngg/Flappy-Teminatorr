using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionHandler : MonoBehaviour
{
    public event Action<Iinteractable> CollisionDetected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Iinteractable>(out Iinteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }
}
