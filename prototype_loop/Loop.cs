using Godot;
using System;

public partial class Loop : Path2D
{

	[Export] private Line2D _Line;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_Line.Width = 5;
		_FillLine();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _FillLine()
	{
		foreach (Vector2 point in Curve.GetBakedPoints())
		{
			_Line.AddPoint(point);
		}
	}
}
