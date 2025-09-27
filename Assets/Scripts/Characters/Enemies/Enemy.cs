using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(EnemyShooter))]
[RequireComponent(typeof(EnemyHealth))]
public class Enemy : ShootingCharacter
{
    [SerializeField] private CollisionHandler _collisionHandler;

    private ShootPoint _shootPoint;

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

        if(interactable is ShootPoint shootPoint && shootPoint.IsTaked == false)
        {
            shootPoint.SetIsTaked(true);
            _shootPoint = shootPoint;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ShootPoint>(out ShootPoint shootPoint))
        {
            if(_shootPoint == shootPoint)
            {
                _shootPoint.SetIsTaked(false);
            }
        }
    }
}
