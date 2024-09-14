using Godot;

namespace Premonition.Scenarios.UI
{
    public partial class Start : Control
    {
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            GetNode<Button>("Control/StartButton").GrabFocus();
        }
    }

}