using Godot;

public partial class Staircase : Area3D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    private void OnStaircaseEnterL1(Node3D body)
    {
        if (body is CharacterBody3D character)
        {
            Vector3 newPosition = character.GlobalTransform.Origin;
            newPosition.Y += 2.5f;
            newPosition.X += 2.5f;
            character.GlobalTransform = new Transform3D(character.GlobalBasis, newPosition);
        }
    }

    private void OnStaircaseExitL2(Node3D body)
    {
        if (body is CharacterBody3D character)
        {
            Vector3 newPosition = character.GlobalTransform.Origin;
            newPosition.Y -= 2.5f;
            newPosition.X += 2.5f;
            character.GlobalTransform = new Transform3D(character.GlobalBasis, newPosition);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
