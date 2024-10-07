using Godot;
using System;
using System.IO;

public partial class Main : Node
{
	[Export]
	private PackedScene _EnemyScene;
	[Export]
	private Player _player;
	[Export]
	public Marker2D PlayerStart;
	[Export]
	public Timer StartTimer;
	[Export]
	public Timer EnemySpawnTimer;
	[Export]
	public Timer ScoreTimer;

	[Export]
	public Ui HUD;

	[Export]
	public PathFollow2D EnemySpawnLocation;

	private int _score;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() { }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void NewGame()
	{
		HUD.ShowMessage("Get Ready!");
		_score = 0;
		HUD.UpdateScoreLabel(_score);
		_player.Start(PlayerStart.Position);
		StartTimer.Start();
	}

	public void GameOver()
	{
		HUD.GameOver();
		EnemySpawnTimer.Stop();
		ScoreTimer.Stop();
	}

	private void OnPlayerHit()
	{
		GameOver();
	}

	private void OnStartTimerTimeout()
	{
		ScoreTimer.Start();
		EnemySpawnTimer.Start();
	}

	private void OnScoreTimerTimeout()
	{
		_score++;
		HUD.UpdateScoreLabel(_score);
	}

	private void OnEnemySpawnTimerTimeout()
	{
		EnemySpawnLocation.ProgressRatio = GD.Randf();

		Enemy enemy = _EnemyScene.Instantiate<Enemy>();
		enemy.Position = EnemySpawnLocation.Position;
		enemy.Rotation = EnemySpawnLocation.Rotation + Mathf.Pi / 2;
		AddChild(enemy);
	}
}
