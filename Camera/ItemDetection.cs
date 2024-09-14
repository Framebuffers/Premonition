using Godot;
using Premonition.Managers;
using System;

public partial class ItemDetection : ShapeCast3D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}



	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (this.IsColliding())
		{
			Node? point = this.GetCollider(0) as Node ?? null;
			if (point != null)
			{
				$"Collision detected at {point}".ToConsole();
				$"Node collider: {this.Name}".ToConsole();
			}
		}
	}
}
