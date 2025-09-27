using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _amount;

    private int _startAmont;

    public float Amount => _amount;

    public event Action<Health> Dead;

    public event Action Killed;

    private void Start()
    {
        _startAmont = _amount;
    }

    public void TakeDamage(int damage)
    {
        if(_amount >= damage)
            _amount -= damage;
        else
            _amount = 0;    

        if(_amount <= 0)
        {
            Dead?.Invoke(this);

            if (TryGetComponent(out Enemy _))
                Killed?.Invoke();
        }
    }

    public void SetStartAmount()
    {
        _amount = _startAmont;
    }
}
