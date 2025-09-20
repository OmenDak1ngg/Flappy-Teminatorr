using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour, Iinteractable
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    [SerializeField] private bool _isFacingRight;

    [SerializeField] private CollisionHandler _collisionHandler;

    private Vector2 _startFacing;

    public int Damage => _damage;

    public event Action<Bullet> HittedTarget;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleCollision;
    }

    private void Start()
    {
        _startFacing = transform.rotation.eulerAngles;

        float yRotation = _isFacingRight ? _startFacing.y : _startFacing.y + 180;

        Vector2 defaulRotation = new Vector2(_startFacing.x, yRotation);
    
        transform.rotation = Quaternion.Euler(defaulRotation);

        while (enabled)
        {
            transform.Translate(new Vector3(0, _isFacingRight ? 1 : -1) * _speed * Time.deltaTime);
        }
    }

    private void HandleCollision(Iinteractable interacteable)
    {
        if (interacteable is RemoveZone)
            HittedTarget?.Invoke(this);

        if(interacteable is Terminator terminator)
        {
            terminator.Health.TakeDamage(_damage);
            HittedTarget?.Invoke(this);
        }
    }
}
