using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _amount;

    private int _startAmont;

    public float Amount => _amount;

    public event Action<Health> Dead;

    protected virtual void Start()
    {
        _startAmont = _amount;
    }

    public virtual void TakeDamage(int damage)
    {
        if(_amount >= damage)
            _amount -= damage;
        else
            _amount = 0;    

        if(_amount <= 0)
            Dead?.Invoke(this);
    }

    public virtual void SetStartAmount()
    {
        _amount = _startAmont;
    }
}
