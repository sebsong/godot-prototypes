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
    public static readonly PackedScene RandomMovementScene = LoadScene(MovementPath, "random_movement.tscn");
    public static readonly PackedScene TargetEnemyMovementScene = LoadScene(MovementPath, "target_enemy_movement.tscn");

    /* Attack Scenes */
    public static readonly PackedScene ContactAttackScene = LoadScene(AttackPath, "contact_attack.tscn");

    /* Movement Defaults */
    public const float DefaultMovementSpeed = 300f;

    /* Attack Defaults */
    public const int DefaultDamage = 1;
    public const float DefaultAttackCooldown = 1f;

    public enum ComponentType
    {
        /** Movement Component Types **/
        RandomMovement,
        TargetEnemyMovement,

        /** Attack Component Types **/
        ContactAttack,
    }

    private static readonly Dictionary<ComponentType, PackedScene> TypeToScene = new()
    {
        { ComponentType.RandomMovement, RandomMovementScene },
        { ComponentType.TargetEnemyMovement, TargetEnemyMovementScene },
        { ComponentType.ContactAttack, ContactAttackScene },
    };

    public static T AttachComponent<T>(Node2D owner, ComponentType componentType) where T : Component
    {
        ClearComponents<T>(owner);

        PackedScene componentScene = TypeToScene[componentType];
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

    private static PackedScene LoadScene(string pathPrefix, string sceneFileName)
    {
        return ResourceLoader.Load<PackedScene>($"{pathPrefix}/{sceneFileName}");
    }
}
