using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed = 400;

	[Export]
	public AnimatedSprite2D AnimatedSprite;

	public Vector2 ScreenSize;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		HandleInput(delta);
	}

	private void HandleInput(double delta)
	{
		Vector2 velocity = Vector2.Zero;

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
			AnimatedSprite.Play();
		}
		else
		{
			AnimatedSprite.Stop();
		}

	}

	private void UpdatePosition(Vector2 velocity)
	{
		Position += velocity;
		Position = new Vector2(
				Mathf.Clamp(Position.X, 0, ScreenSize.X),
				Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
			);

	}
}
