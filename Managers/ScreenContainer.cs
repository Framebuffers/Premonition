using Godot;

namespace Premonition.Managers
{
    public partial class ScreenContainer : SubViewportContainer
    {
        private SubViewport _screen2D;
        private SubViewport _screen3D;
        private GameDirector _director;
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _director = this.GetGameDirector();
            _screen2D = _director.ScreenManager.Screen2D;
            _screen3D = _director.ScreenManager.Screen3D;
            this.Resized += OnContainerResized;
            OnContainerResized();
        }

        private void OnContainerResized()
        {
            if (_screen2D != null && _screen3D != null)
            {
                Vector2I size = new((int)GetViewportRect().Size.X,
                                    (int)GetViewportRect().Size.Y);
                _screen2D.Size = size;
                _screen3D.Size = size;
            }
            $"Screen2D Size: {_screen2D.Size.X} x {_screen2D.Size.Y}".ToConsole();
            $"Screen3D Size: {_screen3D.Size.X} x {_screen3D.Size.Y}".ToConsole();
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
        }
    }
}
