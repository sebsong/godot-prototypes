using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportCategory("References")] [Export]
	private Loop _loop;

	[ExportCategory("Stats")] [Export] private float _loopSpeed;

	private PathFollow2D _loopFollow;

	public override void _Ready()
	{
		base._Ready();
		_loopFollow = _loop.GetPathFollow();
		Position = _loopFollow.Position;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		Travel(delta);
	}

	private void Travel(double delta)
	{
		Position = _loopFollow.Position;
		_loopFollow.Progress += (float)(_loopSpeed * delta);
	}
}
