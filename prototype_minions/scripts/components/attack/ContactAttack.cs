using Godot;
using System;
using prototype_minions.scripts;

public partial class ContactAttack : AttackComponent
{
    public override void Attack() {}

    public override void OnCollision(KinematicCollision2D collision)
    {
        if (collision.GetCollider() is Enemy enemy)
        {
            enemy.TakeDamage(Damage);
        }
    }
}
