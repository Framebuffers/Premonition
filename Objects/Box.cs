using Godot;
using Premonition.Camera.Debug;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;
using System;

public partial class Box : Item
{
    public override string Name => "Default Box";

    public override string Storyline0 => "[Not in table]";

    public override string Storyline1 => "[Not in table]";

    public override string Storyline2 => "[Not in table]";

    public override string Storyline3 => "[Not in table]";

    public override string Storyline4 => "[Not in table]";

    public override string Storyline5 => "[Not in table]";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	
}
