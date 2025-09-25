using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ShootPoint : MonoBehaviour
{
    private Enemy _currentEnemy;

    public bool IsTaked { get; private set; }

    private void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        IsTaked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsTaked == false && collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            IsTaked = true;
            _currentEnemy = enemy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy) && enemy == _currentEnemy)
        {
            IsTaked = false;
        }
    }
}
