using Godot;
using System;

public partial class Ball : RigidBody2D
{
	[Export] private Path2D _path;

	[Export] private Line2D _line;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_line.Width = 5;
		_line.DefaultColor = new Color(1, 1, 1);
		_path.Curve.ClearPoints();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var curve = _path.Curve;
		if (curve.GetPointCount() == 0 || curve.GetPointPosition(curve.GetPointCount()-1) != Position)
		{
			_path.Curve.AddPoint(Position);
			_line.AddPoint(Position);
		}
	}

	public void Throw(Vector2 velocity)
	{
		LinearVelocity = Vector2.Zero;
		ApplyImpulse(velocity);
	}
}
