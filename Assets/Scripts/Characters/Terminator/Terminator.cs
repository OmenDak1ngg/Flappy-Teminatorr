using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TerminatorMover))]
public class Terminator : ShootingCharacter
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private TerminatorMover _terminatorMover;

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

    private void HandleCollision(Iinteractable interactable)
    {
        if (interactable is RemoveZone)
            ReachedRemoveZone?.Invoke();
    }

    protected override void Awake()
    {
        base.Awake();

        OnRevive();
    }

    public override void OnRevive()
    {
        base.OnRevive();
        transform.position = _startPoint.position;
    }
}
