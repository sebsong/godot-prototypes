using Godot;
using System;

public partial class Player : Node2D
{

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
		// _ApplyGravity(delta);
		_Walk(delta);
	}

	private void _Walk(double delta)
	{
		if (Input.IsActionPressed("walk_left"))
		{
			MoveLocalX((float)(-Speed * delta));
		}
		if (Input.IsActionPressed("walk_right"))
		{
			MoveLocalX((float)(Speed * delta));
		}
	}

	private void _ApplyGravity(double delta)
	{
		MoveLocalY((float)(Gravity * delta));
	}
}
