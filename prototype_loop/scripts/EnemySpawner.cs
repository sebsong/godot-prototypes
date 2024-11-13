using Godot;
using System;

public partial class EnemySpawner : Node2D
{
    [Export]
    private PackedScene _enemyScene;

    [Export]
    private PathFollow2D _pathFollow;

    private void OnSpawnTimerTimeout()
    {
        GD.Print("SPAWN");
        _pathFollow.ProgressRatio = GD.Randf();
        GD.Print(_pathFollow.ProgressRatio);
        Enemy enemy = _enemyScene.Instantiate<Enemy>();
        enemy.Position = _pathFollow.Position;
        AddSibling(enemy);
    }
}
