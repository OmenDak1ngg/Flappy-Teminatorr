using System;
using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _stopDistance = 0.6f;
    
    [SerializeField] private float _moveDelay = 0.5f;

    private Transform _shootPoint;


    private WaitForSeconds _moveWait;

    public event Action ReachedShootPoint;

    private void Start()
    {
        _moveWait = new WaitForSeconds(_moveDelay);
    }

    private IEnumerator MovingToShootPoint()
    {
        while (Vector3.Magnitude(transform.position - _shootPoint.position) >= _stopDistance * _stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _shootPoint.position, _speed * Time.deltaTime);

            yield return _moveWait;
        }

        ReachedShootPoint?.Invoke();
    }

    public void MoveToShootPoint()
    {
        StartCoroutine(MovingToShootPoint());
    }

    public void SetShootPoint(Transform shootPoint)
    {
        _shootPoint = shootPoint;
    }
}
