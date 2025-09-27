using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private ShootPoint[] _shootPoints;
    [SerializeField] private Transform[] _spawnPoints;

    private int _takedShootPoints;

    private WaitForSeconds _spawnWait;

    public event Action<Enemy> EnemySpawned;

    protected override void Awake()
    {
        _spawnWait = new WaitForSeconds(_spawnDelay);

        _takedShootPoints = 0;

        base.Awake();

        StartCoroutine(SpawnEnemies());
    }

    private void OnEnemyOutBounds(Health health)
    {
        if (health.TryGetComponent<Enemy>(out Enemy enemy))
        {
            ReleaseObject(enemy);
        }
    }

    private ShootPoint SetRandomShootPoint()
    {
        int shootPointIndex = UnityEngine.Random.Range(0, _shootPoints.Length);

        while (_shootPoints[shootPointIndex].IsTaked)
            shootPointIndex = (shootPointIndex + 1) % _shootPoints.Length;

        return _shootPoints[shootPointIndex];
    }

    private Vector3 SetRandomSpawnPoint()
    {
        return _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)].position;
    }

    private IEnumerator SpawnEnemies()
    {
        while (enabled)
        {
            yield return _spawnWait;

            if (_takedShootPoints < _shootPoints.Length)
                _pool.Get();             
        }
    }

    protected override Enemy OnInstantiate()
    {
        Enemy enemy = base.OnInstantiate();

        enemy.transform.SetParent(this.transform);

        enemy.ReachedRemoveZone += OnEnemyOutBounds;

        EnemySpawned?.Invoke(enemy);

        return enemy;
    }

    protected override void OnGetObject(Enemy pooledObject)
    {
        EnemyMover mover = pooledObject.GetComponent<EnemyMover>();

        pooledObject.transform.position = SetRandomSpawnPoint();
        mover.SetShootPoint(SetRandomShootPoint());

        _takedShootPoints += 1;

        base.OnGetObject(pooledObject);

        mover.MoveToShootPoint();
    }

    protected override void OnReleaseObject(Enemy pooledObject)
    {
        pooledObject.GetComponent<EnemyShooter>().StopShooting();
        pooledObject.Health.SetStartAmount();
        pooledObject.GetComponent<AnimationController>().ResetAllStates();

        _takedShootPoints -= 1;

        base.OnReleaseObject(pooledObject);
    }

    protected override void OnDestroyObject(Enemy pooledObject)
    {
        pooledObject.ReachedRemoveZone -= OnEnemyOutBounds;

        base.OnDestroyObject(pooledObject);
    }
}
