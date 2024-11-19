using Godot;
using System;
using Godot.Collections;
using prototype_minions.scripts;

public partial class EnemyTargetMovement : MovementComponent
{
    private Enemy _enemyTarget;

    public override void _Ready()
    {
        base._Ready();
        UpdateEnemyTarget();
    }

    public override Vector2 GetVelocity()
    {
        if (!IsInstanceValid(_enemyTarget))
        {
            UpdateEnemyTarget();
        }

        if (_enemyTarget == null)
        {
            return Vector2.Zero;
        }

        return (_enemyTarget.Position - GlobalPosition).Normalized() * Speed;
    }

    public override void OnCollision(KinematicCollision2D collision)
    {
        if (collision.GetCollider() is Enemy)
        {
            UpdateEnemyTarget();
        }
    }

    private void UpdateEnemyTarget()
    {
        Array<Node> allEnemies = GetTree().GetNodesInGroup("enemies");
        if (allEnemies.Count == 0)
        {
            _enemyTarget = null;
        }
        else
        {
            _enemyTarget = allEnemies.PickRandom() as Enemy;
        }
    }
}