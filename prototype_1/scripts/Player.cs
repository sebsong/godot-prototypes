using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportCategory("Movement")]
	[Export]
	public float Speed;
	[Export]
	public float Gravity;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_Walk();
		MoveAndSlide();
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		_ApplyGravity();
	}

	private void _Walk()
	{
		float velocityX = Velocity.X;
		if (Input.IsActionJustReleased("walk_left") && Velocity.X < 0)
		{
			velocityX = 0;
		}
		if (Input.IsActionJustReleased("walk_right") && Velocity.X > 0)
		{
			velocityX = 0;
		}
		if (Input.IsActionPressed("walk_left"))
		{
			velocityX = -Speed;
		}
		if (Input.IsActionPressed("walk_right"))
		{
			velocityX = Speed;
		}
		Velocity = new Vector2(velocityX, Velocity.Y);
	}

	private void _ApplyGravity()
	{
		Velocity = new Vector2(Velocity.X, Gravity);
	}
}
