using System;
using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    [SerializeField] private InputReader _inputReader;

    private WaitForSeconds _shootWait;

    private bool _canShoot;

    public Transform ShootPoint =>  _shootPoint;

    public event Action Shooted;

    private void OnEnable()
    {
        _inputReader.Shooted += OnShoot;
    }

    private void OnDisable()
    {
        _inputReader.Shooted -= OnShoot;
    }

    private void Start()
    {
        _canShoot = true;
        _shootWait = new WaitForSeconds(_shootDelay);
    }

    private void OnShoot()
    {
        if (_canShoot)
        {
            Debug.Log("signalized to shoot");
            Shooted?.Invoke();
            StartCoroutine(ShootReload());
        }
    }

    private IEnumerator ShootReload()
    {
        _canShoot = false;

        yield return _shootWait;

        _canShoot = true;
    }
}
