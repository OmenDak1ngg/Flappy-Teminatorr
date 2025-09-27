using System.Collections;
using UnityEngine;

public class PlayerShooter : Shooter
{
    [SerializeField] private InputReader _inputReader;

    private bool _canShoot;

    private void OnEnable()
    {
        _inputReader.Shooted += OnShoot;
    }

    private void OnDisable()
    {
        _inputReader.Shooted -= OnShoot;
    }

    protected override void Start()
    {
        _canShoot = true;
        base.Start();
    }

    protected override void OnShoot()
    {
        if (_canShoot)
        { 
            base.OnShoot();
            StartCoroutine(ShootReload());
        }
    }

    private IEnumerator ShootReload()
    {
        _canShoot = false;

        yield return ShootWait;

        _canShoot = true;
    }
}
