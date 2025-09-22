using System;
using UnityEngine;

public class Terminator : ShootingCharacter
{
    [SerializeField] private CollisionHandler _collisionHandler;

    [SerializeField] private Transform _startPoint;

    public event Action ReachedRemoveZone;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleCollision;
    }

    protected override void Start()
    {
        TeleportToStartPoint();

        base.Start();
    }

    private void HandleCollision(Iinteractable interactable)
    {
        if (interactable is RemoveZone)
            ReachedRemoveZone?.Invoke();
    }

    public void TeleportToStartPoint()
    {
        transform.position = _startPoint.position;
    }
}
