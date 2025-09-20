using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;

    protected ObjectPool<T> _pool;

    protected virtual void Start()
    {
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
    }

    protected virtual void OnReleaseObject(T pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    protected virtual void OnDestroyObject(T pooledObject)
    {
        Destroy(pooledObject);
    }
}
