using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : Health
{
    private bool _isDead;

    protected override void Start()
    {
        base.Start();

        _isDead = false;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (Amount <= 0 && _isDead == false)
        {
            _isDead = true;
            GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<ScoreCounter>().Increase();
        }
    }

    public override void SetStartAmount()
    {
        base.SetStartAmount();
        _isDead = false;
    }
}
