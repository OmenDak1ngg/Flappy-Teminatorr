using System.Runtime.InteropServices;
using UnityEngine;

public abstract class ShootingCharacter : MonoBehaviour, Iinteractable
{
    [SerializeField] private Health _health;

    [SerializeField] private CollisionHandler _collisionHandler;

    public Health Health => _health;

    protected virtual void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleCollision;
    }

    protected virtual void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleCollision;
    }

    protected abstract void HandleCollision(Iinteractable interactable);
}
