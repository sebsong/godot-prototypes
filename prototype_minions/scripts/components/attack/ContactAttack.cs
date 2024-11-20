using Godot;
using System;
using prototype_minions.scripts;

public partial class ContactAttack : AttackComponent
{
    private double _timeSinceLastAttack;
    private Enemy _lastEnemyHit;

    public override void Attack(double delta)
    {
        _timeSinceLastAttack += delta;
    }

    public override void OnCollision(KinematicCollision2D collision)
    {
        if (collision.GetCollider() is Enemy enemy)
        {
            if (enemy == _lastEnemyHit && _timeSinceLastAttack < AttackCooldown)
            {
                return;
            }
            enemy.TakeDamage(Damage);
            _lastEnemyHit = enemy;
            _timeSinceLastAttack = 0;
        }
    }
}
