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

    public static readonly PackedScene TargetEnemyMovementScene =
        LoadScene($"{MovementPath}/target_enemy_movement.tscn");

    /* Attack Scenes */
    public static readonly PackedScene ContactAttackScene = LoadScene($"{AttackPath}/contact_attack.tscn");

    /* Movement Defaults */
    public const float DefaultMovementSpeed = 300f;

    /* Attack Defaults */
    public const int DefaultDamage = 1;
    public const float DefaultAttackCooldown = 1f;
    
    public enum MovementComponents
    {
        Random,
        TargetEnemy,
    }

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
