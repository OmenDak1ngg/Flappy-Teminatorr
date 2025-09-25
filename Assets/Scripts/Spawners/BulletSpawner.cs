using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{ 
    [SerializeField] private int _bulletOwnerLayerIndex;

    protected override Bullet OnInstantiate()
    {
        Bullet bullet =  base.OnInstantiate();
        
        bullet.SetOwnerLayerMask(_bulletOwnerLayerIndex);

        bullet.HittedTarget += ReleaseObject;

        return bullet;
    }

    protected override void OnReleaseObject(Bullet pooledObject)
    {
        base.OnReleaseObject(pooledObject);
    }

    protected override void OnDestroyObject(Bullet pooledObject)
    {
        pooledObject.HittedTarget -= ReleaseObject;

        base.OnDestroyObject(pooledObject);
    }

    public Bullet GetBullet()
    {
        return _pool.Get();
    }

}
