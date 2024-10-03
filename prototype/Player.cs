using Godot;
using System;

public partial class Player : Area2D
{
	[Signal]
	public delegate void HitEventHandler();

	[Export]
	public int Speed = 400;
	[Export]
	private AnimatedSprite2D AnimatedSprite;
	[Export]
	private CollisionShape2D CollisionShape;

	private Vector2 _ScreenSize;
	private Vector2 _PlayerSize;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_ScreenSize = GetViewportRect().Size;
		_PlayerSize = CollisionShape.Shape.GetRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		HandleInput(delta);
	}

	private void OnBodyEntered(Node2D body)
	{
		EmitSignal(SignalName.Hit);
		KillPlayer();
	}

	private void RevivePlayer()
	{
		Show();
		CollisionShape.SetDeferred(CollisionShape2D.PropertyName.Disabled, false);
	}

	private void KillPlayer()
	{
		Hide();
		CollisionShape.SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
	}

	private void HandleInput(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		if (Input.IsActionPressed("quit"))
		{
			GetTree().Quit();
		}
		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}
		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}
		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}
		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}

		if (!velocity.IsZeroApprox())
		{
			velocity = velocity.Normalized() * Speed * (float)delta;
			UpdatePosition(velocity);
			MovementAnimation(velocity);
		}
		else
		{
			AnimatedSprite.Stop();
		}

	}

	private void MovementAnimation(Vector2 velocity)
	{

		string AnimationName = "walk";
		if (velocity.X != 0)
		{
			AnimatedSprite.FlipH = velocity.X < 0;
		}

		if (velocity.Y != 0)
		{
			AnimationName = "up";
			AnimatedSprite.FlipV = velocity.Y > 0;
		}
		AnimatedSprite.Play(new StringName(AnimationName));
	}

	private void UpdatePosition(Vector2 velocity)
	{
		Position += velocity;
		Position = new Vector2(
				Mathf.Clamp(Position.X, _PlayerSize.X, _ScreenSize.X - _PlayerSize.X),
				Mathf.Clamp(Position.Y, _PlayerSize.Y, _ScreenSize.Y - _PlayerSize.Y)
			);

	}
}
