using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] private float _throwSpeed;

	[ExportCategory("Movement")] [Export] private float _speed;
	[Export] private float _rideSpeed;
	[Export] private float _jumpSpeed;
	[Export] private float _gravity;

	private PackedScene _ballScene = GD.Load<PackedScene>("res://scenes/ball.tscn");
	private Ball _ball;
	private PathFollow2D _currentPath;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_CheckWalk();
		if (_IsPathSet())
		{
			_RidePath(delta);
			_CheckJump(delta);
		}
		else
		{
			_CheckRidePath(delta);
		}

		if (_ball == null)
		{
			_CheckThrowBall();
		}
		else
		{
			_CheckRecallBall();
		}

		MoveAndSlide();
	}

	private void _RidePath(double delta)
	{
		Position = _currentPath.Position;
		_currentPath.Progress += (float)(_rideSpeed * delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		_ApplyGravity(delta);
	}

	private void _CheckWalk()
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

	private void _CheckRidePath(double delta)
	{
		if (Input.IsActionJustPressed("ride_path"))
		{
			if (_ball == null) return;
			PathFollow2D pathFollow = _ball.FindChild("PathFollow2D") as PathFollow2D;
			_SetPath(pathFollow);
		}
	}

	private void _CheckJump(double delta)
	{
		if (Input.IsActionJustPressed("jump"))
		{
			_ClearPath();
			Velocity = new Vector2(Velocity.X, -_jumpSpeed);
		}
	}

	private void _CheckThrowBall()
	{
		if (Input.IsActionJustPressed("throw_ball"))
		{
			var mousePosition = GetViewport().GetMousePosition();
			var velocity = (mousePosition - GlobalPosition).Normalized() * _throwSpeed;
			_ThrowBall(velocity);
		}
	}

	private void _ThrowBall(Vector2 velocity)
	{
		_ball = _ballScene.Instantiate() as Ball;
		if (_ball == null) return;
		AddChild(_ball);
		_ball.Position = Position;
		_ball.Throw(velocity);
	}
	
	private void _CheckRecallBall()
	{
		if (Input.IsActionJustPressed("recall_ball"))
		{
			_ball.QueueFree();
			_ball = null;
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
