using Godot;
using System;

public partial class Minion : CharacterBody2D
{
	[Export]
	private float _speed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Velocity = GenerateRandomVelocity();
		GD.Print(Velocity);
		MoveAndSlide();
	}

	private Vector2 GenerateRandomVelocity()
	{
		float x = GD.RandRange(-1, 1);
		float y = GD.RandRange(-1, 1);
		return new Vector2(x, y).Normalized() * _speed;
	}
}
