namespace prototype_minions.scripts;

using Godot;

public abstract partial class AttackComponent : Component
{
    [Export] internal int Damage = ComponentUtils.DefaultDamage;

    public abstract void Attack();

    public abstract void OnCollision(KinematicCollision2D collision);
}
