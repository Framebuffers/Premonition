using Godot;

namespace Premonition.Transitions
{
    public partial class Staircase : Area3D
    {
        // Called when the node enters the scene tree for the first time.

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

    }
}
