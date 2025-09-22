using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _spawnDelay;

    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Transform[] _spawnPoints;

    private WaitForSeconds _spawnWait;

    protected override void Awake()
    {
        _spawnWait = new WaitForSeconds(_spawnDelay);

        base.Awake();

        StartCoroutine(SpawnEnemies());
    }

    private void OnEnemyDead(Health health)
    {
        if (health.TryGetComponent<Enemy>(out Enemy enemy))
        {
            OnReleaseObject(enemy);
        }
    }

    private Transform SetRandomShootPoint()
    {
        return _shootPoints[Random.Range(0, _shootPoints.Length)];
    }

    private Vector3 SetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0,_shootPoints.Length)].position;   
    }

    private IEnumerator SpawnEnemies()
    {
        while (enabled)
        {
            yield return _spawnWait;

            _pool.Get();
        }
    }

    protected override Enemy OnInstantiate()
    {
        Enemy enemy = base.OnInstantiate();

        enemy.transform.SetParent(this.transform);

        enemy.ReachedRemoveZone += OnEnemyDead;

        return enemy;
    }

    protected override void OnGetObject(Enemy pooledObject)
    {
        EnemyMover mover = pooledObject.GetComponent<EnemyMover>();

        pooledObject.transform.position = SetRandomSpawnPoint();
        mover.SetShootPoint(SetRandomShootPoint());

        mover.MoveToShootPoint();

        base.OnGetObject(pooledObject);
    }

    protected override void OnReleaseObject(Enemy pooledObject)
    {
        pooledObject.GetComponent<EnemyShooter>().StopShooting();
        pooledObject.Health.SetStartAmount();

        pooledObject.GetComponent<AnimationController>().ResetAllStates();
        base.OnReleaseObject(pooledObject);
    }

    protected override void OnDestroyObject(Enemy pooledObject)
    {
        pooledObject.ReachedRemoveZone -= OnEnemyDead;

        base.OnDestroyObject(pooledObject);
    }
}
