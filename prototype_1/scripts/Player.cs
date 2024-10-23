using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public Ball Ball;

	[ExportCategory("Movement")]
	[Export]
	public float Speed;
	[Export]
	public float RideSpeed;
	[Export]
	public float Gravity;

	private PathFollow2D _CurrentPath;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_RidePath(delta);
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
	private void _RidePath(double delta)
	{
		if (Input.IsActionJustPressed("ride_path"))
		{
			PathFollow2D pathFollow = Ball.FindChild("PathFollow2D") as PathFollow2D;
			if (_CurrentPath == null)
			{
				_CurrentPath = pathFollow;
			}
		}

		if (_CurrentPath != null)
		{
			Position = _CurrentPath.Position;
			_CurrentPath.Progress += (float)(RideSpeed * delta);
		}
	}

	private void _ApplyGravity()
	{
		Velocity = new Vector2(Velocity.X, Gravity);
	}
}
