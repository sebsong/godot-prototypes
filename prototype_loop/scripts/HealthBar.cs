using Godot;
using System;

public partial class HealthBar : Node2D
{
    [Export]
    private TextureProgressBar _progressBar;

    public void Lower(int amount)
    {
        _progressBar.Value -= amount;
    }

    public void Raise(int amount)
    {
        _progressBar.Value += amount;
    }
}
