using Godot;
using System;
using prototype_minions.scripts;

public partial class Minion : CharacterBody2D
{
	private MovementComponent _movementComponent;
	private AttackComponent _attackComponent;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_movementComponent = ComponentDefaults.DefaultMovementComponent.Instantiate<MovementComponent>();
		AddChild(_movementComponent);

		_attackComponent = ComponentDefaults.DefaultAttackComponent.Instantiate<AttackComponent>();
		AddChild(_attackComponent);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Velocity = _movementComponent.GetVelocity();
		_attackComponent.Attack();
		if (MoveAndSlide())
		{
			KinematicCollision2D collision = GetLastSlideCollision();
			_movementComponent.OnCollision(collision);
			_attackComponent.OnCollision(collision);
		}
	}
}