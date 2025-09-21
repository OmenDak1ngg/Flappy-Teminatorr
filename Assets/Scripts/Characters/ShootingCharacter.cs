using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Health))]
public abstract class ShootingCharacter : MonoBehaviour, Iinteractable
{
    [SerializeField] private Health _health;

    public Health Health => _health;

    protected virtual void Start()
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}
