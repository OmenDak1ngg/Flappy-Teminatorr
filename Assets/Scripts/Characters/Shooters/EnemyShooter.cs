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

    protected override void Start()
    {
        base.Start();

        BulletSpawner = GameObject.FindWithTag("EnemyBulletSpawner").GetComponent<BulletSpawner>();
    }

    private IEnumerator ShootContinously()
    {
        while (enabled)
        {
            yield return ShootWait;

            OnShoot();
        }
    }

    public void StartShooting()
    {
        _shootingCoroutine = StartCoroutine(ShootContinously());
    }

    public void StopShooting()
    {
        if (_shootingCoroutine == null)
            return;

        StopCoroutine(_shootingCoroutine);
    }
}
