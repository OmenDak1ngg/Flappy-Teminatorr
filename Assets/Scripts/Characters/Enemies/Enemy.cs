using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(CollisionHandler))]
public class Enemy : ShootingCharacter
{
    [SerializeField] private CollisionHandler _collisionHandler;

    public event Action<Health> ReachedRemoveZone;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleCollision;
    }

    private void HandleCollision(Iinteractable interactable)
    {
        if (interactable is RemoveZone)
            ReachedRemoveZone?.Invoke(GetComponent<Health>());
    }
}
