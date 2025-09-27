using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : BaseSpawner where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;

    private List<T> _activeObjects;

    protected ObjectPool<T> _pool;

    protected virtual void Awake()
    {
        _activeObjects = new List<T>();

        _pool = new ObjectPool<T>(
            createFunc: () => OnInstantiate(),
            actionOnGet: (T pooledObject) => OnGetObject(pooledObject),
            actionOnRelease: (T pooledObject) => OnReleaseObject(pooledObject),
            actionOnDestroy: (T pooledObject) => OnDestroyObject(pooledObject)
            );
    }

    protected virtual T OnInstantiate()
    {
        return Instantiate(_prefab);
    }

    protected virtual void OnGetObject(T pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
        _activeObjects.Add(pooledObject);
    }

    protected virtual void OnReleaseObject(T pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        _activeObjects.Remove(pooledObject);
    }

    protected virtual void OnDestroyObject(T pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    protected virtual void ReleaseObject(T pooledObject)
    {
        _pool.Release(pooledObject);
    }

    public override void ReleaseAllObjects()
    {
        for (int i = _activeObjects.Count - 1; i >= 0; i--)
        {
            _pool.Release(_activeObjects[i]);
        }
    }
}
