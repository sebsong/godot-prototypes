using Godot;
using System;
using prototype_minions.scripts;

public partial class Minion : CharacterBody2D
{
	private MovementComponent _movementComponent;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_movementComponent = ComponentDefaults.DefaultMovementComponent.Instantiate<RandomMovement>();
		AddChild(_movementComponent);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Velocity = _movementComponent.GetVelocity();
		if (MoveAndSlide())
		{
			_movementComponent.OnCollision();
		}
	}
}
