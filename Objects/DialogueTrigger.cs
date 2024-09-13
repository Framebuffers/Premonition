using Godot;
using Premonition.Managers;
using System;

public partial class DialogueTrigger : Area3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	
	private void OnDialogueEnter(Node3D body)
	{
		$"Area entered".ToConsole();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
