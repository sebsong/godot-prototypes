using Godot;
using System;
using prototype_minions.scripts;

public partial class RandomMovement : MovementComponent
{
    [Export] private float _speed;

    [Export] private Timer _velocityChangeTimer;
    [Export] private float _minTimerDuration;
    [Export] private float _maxTimerDuration;

    private Vector2 _currentVelocity;
    private RandomNumberGenerator _rng = new();

    public override void _Ready()
    {
        base._Ready();
        UpdateVelocity();
    }

    public override Vector2 GetVelocity()
    {
        return _currentVelocity;
    }

    public override void OnCollision()
    {
        UpdateVelocity();
    }

    private void UpdateVelocity()
    {
        _currentVelocity = GenerateRandomVelocity();
    }

    private Vector2 GenerateRandomVelocity()
    {
        float x = _rng.RandfRange(-1f, 1f);
        float y = _rng.RandfRange(-1f, 1f);
        return new Vector2(x, y).Normalized() * _speed;
    }

    private void OnVelocityChangeTimerTimeout()
    {
        UpdateVelocity();
        _velocityChangeTimer.WaitTime = _rng.RandfRange(_minTimerDuration, _maxTimerDuration);
    }

}
