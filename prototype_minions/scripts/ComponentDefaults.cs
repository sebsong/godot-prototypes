using Godot;

namespace prototype_minions.scripts;

public static class ComponentDefaults
{
    public static PackedScene DefaultMovementComponent = ResourceLoader.Load<PackedScene>("res://scenes/components/movement/random_movement.tscn");
}
