using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    [SerializeField] protected BulletSpawner BulletSpawner;

    protected WaitForSeconds ShootWait;

    public Transform ShootPoint => _shootPoint;

    protected virtual void Start()
    {
        ShootWait = new WaitForSeconds(_shootDelay);
    }

    protected virtual void OnShoot()
    {
        Bullet bullet = BulletSpawner.GetBullet();

        bullet.transform.position = _shootPoint.transform.position;
    }
}
