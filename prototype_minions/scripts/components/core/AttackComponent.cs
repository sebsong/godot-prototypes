namespace prototype_minions.scripts;

using Godot;

public abstract partial class AttackComponent : Node2D
{
    public abstract void Attack();

    public abstract void OnCollision(KinematicCollision2D collision);
}
