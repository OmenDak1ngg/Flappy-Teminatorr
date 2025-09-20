using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _amount;

    public float Amount => _amount;

    public void TakeDamage(int damage)
    {
        if(_amount >= damage)
            _amount -= damage;
        else
            _amount = 0;    
    }
}
