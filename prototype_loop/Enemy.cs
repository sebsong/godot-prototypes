using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    public void TakeDamage(int amount)
    {
        QueueFree();
    }
}
