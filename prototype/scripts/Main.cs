using Godot;
using System;

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

	private int _score;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		NewGame();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void NewGame()
	{
		_score = 0;
		_player.Start(PlayerStart.Position);
		StartTimer.Start();
	}

	public void GameOver()
	{
		EnemySpawnTimer.Stop();
		ScoreTimer.Stop();
	}

	private void OnStartTimerTimeout()
	{
		ScoreTimer.Start();
		EnemySpawnTimer.Start();
	}

	private void OnScoreTimerTimeout()
	{
		_score++;
	}

	private void OnEnemySpawnTimerTimeout()
	{

	}
}
