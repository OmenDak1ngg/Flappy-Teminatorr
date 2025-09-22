using System;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    [SerializeField] private bool _isFacingRight;

    [SerializeField] private CollisionHandler _collisionHandler;

    private int _ownerLayerIndex;

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
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void Update()
    {
        transform.Translate(new Vector3(_isFacingRight ? 1 : -1,0) * _speed * Time.deltaTime);
    }

    private void HandleCollision(Iinteractable interacteable)
    {
        if (interacteable is RemoveZone)
        {
            HittedTarget?.Invoke(this);
        }

        if(interacteable is ShootingCharacter character)
        {
            if (character.gameObject.layer == _ownerLayerIndex)
                return;

            character.Health.TakeDamage(_damage);
            HittedTarget?.Invoke(this);
        }
    }

    public void SetOwnerLayerMask(int layerIndex)
    {
        _ownerLayerIndex = layerIndex;
    }
}
