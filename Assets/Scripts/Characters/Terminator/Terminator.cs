using UnityEngine;

public class Terminator : ShootingCharacter
{
    [SerializeField] private TerminatorMover _mover;

    protected override void HandleCollision(Iinteractable interactable)
    {
        if(interactable is Bullet bullet)
        {
            Health.TakeDamage(bullet.Damage);
        }
    }
}
