using Godot;
using System;

public partial class Ui : CanvasLayer
{
	[Signal]
	public delegate void StartGameEventHandler();

	[Export]
	public Label ScoreLabel;
	[Export]
	public Label Message;
	[Export]
	public Timer MessageTimer;
	[Export]
	public Button StartButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void UpdateScoreLabel(int score)
	{
		ScoreLabel.Text = score.ToString();

	}

	async public void GameOver()
	{
		ShowMessage("Game Over");

		await ToSignal(MessageTimer, Timer.SignalName.Timeout);

		ShowMessage("Dodge the swimmies!");

		StartButton.Show();
	}

	public void ShowMessage(string text)
	{
		Message.Text = text;
		Message.Show();

		MessageTimer.Start();
	}


	private void OnStartButtonPressed()
	{
		StartButton.Hide();
		EmitSignal(SignalName.StartGame);
	}

	private void OnMessageTimerTimeout()
	{
		Message.Hide();
	}
}
