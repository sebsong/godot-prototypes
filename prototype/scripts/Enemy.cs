using Godot;
using System;

public partial class Enemy : RigidBody2D
{
	[Export]
	private AnimatedSprite2D _AnimatedSprite;
	private string _AnimationName;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		string[] animationNames = _AnimatedSprite.SpriteFrames.GetAnimationNames();
		_AnimationName = animationNames[GD.Randi() % animationNames.Length];
		_AnimatedSprite.Play(_AnimationName);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
