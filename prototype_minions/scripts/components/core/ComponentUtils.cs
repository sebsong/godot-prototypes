using System;
using Godot;
using Godot.Collections;

namespace prototype_minions.scripts;

public static class ComponentUtils
{
    private const string ComponentsPath = "res://scenes/components";
    private const string MovementPath = ComponentsPath + "/movement";
    private const string AttackPath = ComponentsPath + "/attack";

    /* Movement Scenes */
    public static readonly PackedScene RandomMovementScene = LoadScene($"{MovementPath}/random_movement.tscn");

    public static readonly PackedScene EnemyTargetMovementScene =
        LoadScene($"{MovementPath}/enemy_target_movement.tscn");

    /* Attack Scenes */
    public static readonly PackedScene ContactAttackScene = LoadScene($"{AttackPath}/contact_attack.tscn");

    public const float DefaultMovementSpeed = 300f;
    public const int DefaultDamage = 1;

    public static T AttachComponent<T>(Node2D owner, PackedScene componentScene) where T : Component
    {
        ClearComponents<T>(owner);

        T component = componentScene.Instantiate<T>();
        owner.AddChild(component);
        return component;
    }

    private static void ClearComponents<T>(Node2D owner)
    {
        Array<Node> componentNodes = owner.FindChildren("*", typeof(T).Name);
        foreach (var node in componentNodes)
        {
            owner.RemoveChild(node);
        }
    }

    private static PackedScene LoadScene(string path)
    {
        return ResourceLoader.Load<PackedScene>(path);
    }
}
