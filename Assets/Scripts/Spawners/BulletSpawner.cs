using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private PlayerShooter _shooter;

    private void OnEnable()
    {
        _shooter.Shooted += GetBullet;
    }

    private void OnDisable()
    {
        _shooter.Shooted -= GetBullet;
    }

    private void GetBullet()
    {
        _pool.Get();
    }

    protected override Bullet OnInstantiate()
    {
        Bullet bullet =  base.OnInstantiate();

        bullet.HittedTarget += OnReleaseObject;

        return bullet;
    }

    protected override void OnGetObject(Bullet pooledObject)
    {
        pooledObject.transform.position = _shooter.ShootPoint.position;
        base.OnGetObject(pooledObject);
    }

    protected override void OnDestroyObject(Bullet pooledObject)
    {
        pooledObject.HittedTarget -= OnReleaseObject;

        base.OnDestroyObject(pooledObject);
    }
}
