namespace prototype_minions.scripts;

using Godot;

public abstract partial class MovementComponent : Node2D
{
    public abstract Vector2 GetVelocity();

    public abstract void OnCollision(KinematicCollision2D collision);
}
