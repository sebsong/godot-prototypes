using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] private Ball _ball;

	[ExportCategory("Movement")] [Export] private float _speed;
	[Export] private float _rideSpeed;
	[Export] private float _jumpSpeed;
	[Export] private float _gravity;

	private PathFollow2D _currentPath;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_Walk();
		if (_IsPathSet())
		{
			Position = _currentPath.Position;
			_currentPath.Progress += (float)(_rideSpeed * delta);
			_Jump(delta);
		}
		else
		{
			_RidePath(delta);
		}

		MoveAndSlide();
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		_ApplyGravity(delta);
	}

	private void _Walk()
	{
		var velocityX = Velocity.X;
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
			velocityX = -_speed;
		}

		if (Input.IsActionPressed("walk_right"))
		{
			velocityX = _speed;
		}

		Velocity = new Vector2(velocityX, Velocity.Y);
	}

	private void _RidePath(double delta)
	{
		if (Input.IsActionJustPressed("ride_path"))
		{
			PathFollow2D pathFollow = _ball.FindChild("PathFollow2D") as PathFollow2D;
			_SetPath(pathFollow);
		}
	}

	private void _Jump(double delta)
	{
		if (Input.IsActionJustPressed("jump"))
		{
			_ClearPath();
			Velocity = new Vector2(Velocity.X, -_jumpSpeed);
		}
	}

	private void _ApplyGravity(double delta)
	{
		Velocity = new Vector2(Velocity.X, Velocity.Y + (float)(_gravity * delta));
	}

	private bool _IsPathSet()
	{
		return _currentPath != null;
	}

	private void _SetPath(PathFollow2D path)
	{
		_currentPath = path;
	}

	private void _ClearPath()
	{
		_currentPath = null;
	}
}
