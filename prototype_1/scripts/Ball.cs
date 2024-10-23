using Godot;
using System;

public partial class Ball : RigidBody2D
{
	[Export]
	public Path2D Path;

	[Export]
	private Line2D Line;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Line.Width = 5;
		Line.DefaultColor = new Color(1, 1, 1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Path.Curve.AddPoint(Position);
		Line.AddPoint(Position);
	}
}
