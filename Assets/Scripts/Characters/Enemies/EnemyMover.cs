using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _stopDistance = 0.3f;

    private Vector3 _shootPoint;

    public event Action ReachedShootPoint;

    public void MoveToShootPoint()
    {
        while(Vector3.Magnitude(transform.position - _shootPoint) >= _stopDistance * _stopDistance)
            transform.position = Vector3.MoveTowards(transform.position, _shootPoint, _speed * Time.deltaTime);

        ReachedShootPoint?.Invoke();
    }

    public void SetShootPoint(Vector3 shootPoint)
    {
        _shootPoint = shootPoint;
    }
}
