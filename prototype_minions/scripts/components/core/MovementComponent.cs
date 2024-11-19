namespace prototype_minions.scripts;

using Godot;

public abstract partial class MovementComponent : Node2D
{
    [Export] internal float Speed = ComponentDefaults.DefaultMovementSpeed;

    public abstract Vector2 GetVelocity();

    public abstract void OnCollision(KinematicCollision2D collision);
}
