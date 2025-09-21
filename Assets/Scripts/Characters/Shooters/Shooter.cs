using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    protected WaitForSeconds ShootWait;

    public Transform ShootPoint => _shootPoint;

    public event Action Shooted;

    protected virtual void Start()
    {
        ShootWait = new WaitForSeconds(_shootDelay);
    }

    protected virtual void OnShoot()
    {
        Shooted?.Invoke();
    }
}
