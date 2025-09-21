using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _spawnDelay;

    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Transform[] _spawnPoints;

    private WaitForSeconds _spawnWait;

    protected override void Start()
    {
        _spawnWait = new WaitForSeconds(_spawnDelay);

        base.Start();

        StartCoroutine(SpawnEnemies());
    }

    private void OnEnemyDead(Health health)
    {
        if (health.TryGetComponent<Enemy>(out Enemy enemy))
        {
            OnReleaseObject(enemy);
        }
    }

    private Vector3 SetRandomShootPoint()
    {
        return _shootPoints[Random.Range(0, _shootPoints.Length)].position;
    }

    private Vector3 SetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0,_shootPoints.Length)].position;   
    }

    private IEnumerator SpawnEnemies()
    {
        while (enabled)
        {
            _pool.Get();
            yield return _spawnWait;
        }
    }

    protected override Enemy OnInstantiate()
    {
        Enemy enemy = base.OnInstantiate();

        enemy.Health.Dead += OnEnemyDead;

        return enemy;
    }

    protected override void OnGetObject(Enemy pooledObject)
    {
        Debug.Log(pooledObject.GetComponent<EnemyMover>() == null);

        EnemyMover mover = pooledObject.GetComponent<EnemyMover>();

        mover.MoveToShootPoint();
        pooledObject.transform.position = SetRandomSpawnPoint();
        mover.SetShootPoint(SetRandomShootPoint());

        mover.MoveToShootPoint();

        base.OnGetObject(pooledObject);
    }

    protected override void OnReleaseObject(Enemy pooledObject)
    {
        pooledObject.GetComponent<EnemyShooter>().StopShooting();

        base.OnReleaseObject(pooledObject);
    }

    protected override void OnDestroyObject(Enemy pooledObject)
    {
        pooledObject.Health.Dead -= OnEnemyDead;

        base.OnDestroyObject(pooledObject);
    }
}
