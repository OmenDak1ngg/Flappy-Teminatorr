using System.Collections;
using UnityEngine;


public class EnemyShooter : Shooter
{
    [SerializeField] private EnemyMover _mover;

    private Coroutine _shootingCoroutine;

    private void OnEnable()
    {
        _mover.ReachedShootPoint += StartShooting;
    }

    private void OnDisable()
    {
        _mover.ReachedShootPoint -= StartShooting;
    }

    private IEnumerator ShootContinously()
    {
        while (enabled)
        {
            OnShoot();

            yield return ShootWait;
        }

    }

    protected override void OnShoot()
    {
        base.OnShoot();
    }

    public void StartShooting()
    {
        _shootingCoroutine = StartCoroutine(ShootContinously());
    }

    public void StopShooting()
    {
        StopCoroutine(_shootingCoroutine);
    }
}
