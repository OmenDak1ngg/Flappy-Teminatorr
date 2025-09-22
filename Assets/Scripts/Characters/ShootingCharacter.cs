using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AnimationController))]
public abstract class ShootingCharacter : MonoBehaviour, Iinteractable
{
    [SerializeField] private Health _health;

    public Health Health => _health;

    protected virtual void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
