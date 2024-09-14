using Godot;

namespace Premonition.Camera
{
    public partial class Reticle0 : Reticle
    {

        private int dotSize = 1;

        private Color dotColor = Colors.White;

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            if (Visible) { updateReticleSettings(); }
        }

        private void updateReticleSettings()
        {
            if (dot.GetType() == typeof(Polygon2D))
            {
                Vector2 dotScale = dot.Scale;
                dotScale.X = dotSize;
                dotScale.Y = dotSize;
                dot.Scale = dotScale;
                dot.Color = dotColor;
            }
        }
    }
}
