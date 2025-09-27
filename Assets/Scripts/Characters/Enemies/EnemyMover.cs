using System;
using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance = 0.6f;
    [SerializeField] private float _moveDelay = 0.5f;

    private WaitForSeconds _moveWait;
    
    public ShootPoint ShootPoint { get; private set; }

    public event Action ReachedShootPoint;

    private void Start()
    {
        _moveWait = new WaitForSeconds(_moveDelay);
    }

    private IEnumerator MovingToShootPoint()
    {
        while (Vector3.Magnitude(transform.position - ShootPoint.transform.position) >= _stopDistance * _stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, ShootPoint.transform.position, _speed * Time.deltaTime);

            yield return _moveWait;
        }

        ReachedShootPoint?.Invoke();
    }

    public void MoveToShootPoint()
    {
        StartCoroutine(MovingToShootPoint());
    }

    public void SetShootPoint(ShootPoint shootPoint)
    {
        ShootPoint = shootPoint;
    }
}
