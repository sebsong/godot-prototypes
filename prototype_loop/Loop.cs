using Godot;

public partial class Loop : Path2D
{

	[Export] private Line2D _line;
	[Export] private PathFollow2D _pathFollow;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_line.Width = 5;
		_FillLine();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public PathFollow2D GetPathFollow()
	{
		return _pathFollow;
	}

	private void _FillLine()
	{
		foreach (Vector2 point in Curve.GetBakedPoints())
		{
			_line.AddPoint(point);
		}
	}
}
