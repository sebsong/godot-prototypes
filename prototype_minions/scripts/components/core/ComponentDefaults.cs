using Godot;

namespace prototype_minions.scripts;

public static class ComponentDefaults
{
    public static PackedScene DefaultMovementComponent = ResourceLoader.Load<PackedScene>("res://scenes/components/movement/random_movement.tscn");
    public static PackedScene DefaultAttackComponent = ResourceLoader.Load<PackedScene>("res://scenes/components/attack/contact_attack.tscn");

    public static float DefaultMovementSpeed = 300f;
}
