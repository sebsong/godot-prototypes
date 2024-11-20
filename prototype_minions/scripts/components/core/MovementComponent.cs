namespace prototype_minions.scripts;

using Godot;

public abstract partial class MovementComponent : Component
{
    [Export] internal float Speed = ComponentUtils.DefaultMovementSpeed;

    public abstract Vector2 GetVelocity();

    public abstract void OnCollision(KinematicCollision2D collision);
}
