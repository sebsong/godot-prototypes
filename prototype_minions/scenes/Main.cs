using Godot;
using System;

public partial class Main : Node2D
{
    public override void _Process(double delta)
    {
        base._Process(delta);

        if (Input.IsActionJustPressed("quit"))
        {
            GetTree().Quit();
        }
    }
}
