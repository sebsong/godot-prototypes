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
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_path.Curve.AddPoint(Position);
		_line.AddPoint(Position);
	}

	public void Throw(Vector2 startPosition, Vector2 velocity)
	{
		SetProcess(true);
		// GD.Print("LOCAL:", Position);
		Position = startPosition;
		// Transform = new Transform2D(Vector2.Zero, Vector2.Zero, startPosition);
		Show();
		// ApplyImpulse(velocity);
	}

	public bool IsActive()
	{
		return Visible;
	}

	public void Recall()
	{
		Hide();
		_ResetPath();
		SetProcess(false);
	}

	private void _ResetPath()
	{
		_line.ClearPoints();
		_path.Curve.ClearPoints();
	}
}
