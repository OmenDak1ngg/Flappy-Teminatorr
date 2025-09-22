using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AnimationController))]
public abstract class ShootingCharacter : MonoBehaviour, Iinteractable
{
    [SerializeField] private Health _health;

    private Vector3 _startRotation;

    private Rigidbody2D _rigidbody;

    public Health Health => _health;

    protected virtual void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
        _rigidbody = GetComponent<Rigidbody2D>();

        GetComponent<Collider2D>().isTrigger = true;
    }

    public virtual void OnRevive()
    {
        transform.rotation = Quaternion.Euler(_startRotation);
        _rigidbody.linearVelocity = Vector2.zero;
        _rigidbody.angularVelocity = 0f;
    }
}
