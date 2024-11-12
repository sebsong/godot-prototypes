using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportCategory("References")] [Export]
	private CollisionShape2D _attackHitBoxShape;
	[Export]
	private Timer _attackHitBoxActiveTimer;
	[Export]
	private Loop _loop;

	[ExportCategory("Stats")] [Export]
	private float _loopSpeed;
	[Export] private float _attackHitBoxActiveSeconds;

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
		CheckAction();
	}

	private void Travel(double delta)
	{
		Position = _loopFollow.Position;
		_loopFollow.Progress += (float)(_loopSpeed * delta);
	}

	private void CheckAction()
	{
		if (Input.IsActionJustPressed("action"))
		{
			Attack();
		}
	}

	private void Attack()
	{
		// TODO: play animation
		EnableAttackHitBox();
		_attackHitBoxActiveTimer.Start(_attackHitBoxActiveSeconds);
	}

	private void EnableAttackHitBox()
	{
		_attackHitBoxShape.Disabled = false;
	}

	private void DisableAttackHitBox()
	{
		_attackHitBoxShape.Disabled = true;
	}

	private void OnAttackHitBoxBodyEntered(Node body)
	{
		if (body is Enemy enemy)
		{
			enemy.TakeDamage(1);
		}
	}

	private void OnAttackHitBoxActiveTimerTimeout()
	{
		DisableAttackHitBox();
	}
}
