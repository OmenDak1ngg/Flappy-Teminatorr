using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private Shooter _shooter;

    [SerializeField] private int _bulletOwnerLayerIndex;

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
        
        bullet.SetOwnerLayerMask(_bulletOwnerLayerIndex);

        bullet.HittedTarget += OnReleaseObject;

        return bullet;
    }

    protected override void OnGetObject(Bullet pooledObject)
    {
        Debug.Log("bullet Getted");

        pooledObject.transform.position = _shooter.ShootPoint.position;
        base.OnGetObject(pooledObject);
    }

    protected override void OnReleaseObject(Bullet pooledObject)
    {
        Debug.Log("Released");

        base.OnReleaseObject(pooledObject);
    }

    protected override void OnDestroyObject(Bullet pooledObject)
    {
        pooledObject.HittedTarget -= OnReleaseObject;

        base.OnDestroyObject(pooledObject);
    }
}
