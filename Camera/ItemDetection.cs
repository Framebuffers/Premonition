using Godot;
using Premonition.Managers;

namespace Premonition.Camera
{
    public partial class ItemDetection : ShapeCast3D
    {
        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            if (this.IsColliding())
            {
                Node point = this.GetCollider(0) as Node ?? null;
                if (point != null)
                {
                    $"Collision detected at {point}".ToConsole();
                    $"Node collider: {this.Name}".ToConsole();
                }
            }
        }
    }

}