using Godot;
using System;

public partial class Enemy : RigidBody2D
{
	[Export]
	private double _speedMin;
	[Export]
	private double _speedMax;
	[Export]
	private double _rotationMin;
	[Export]
	private double _rotationMax;
	[Export]
	private AnimatedSprite2D _AnimatedSprite;
	private string _AnimationName;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Randomize();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Randomize()
	{
		string[] animationNames = _AnimatedSprite.SpriteFrames.GetAnimationNames();
		_AnimationName = animationNames[GD.Randi() % animationNames.Length];
		_AnimatedSprite.Play(_AnimationName);

		Rotation += (float)GD.RandRange(_rotationMin, _rotationMax); ;

		double speed = GD.RandRange(_speedMin, _speedMax);
		Vector2 velocity = Vector2.Up * (float)speed;
		LinearVelocity = velocity.Rotated(Rotation + Mathf.Pi / 2);
	}

	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
