using Godot;
using Premonition.Managers;
using Premonition.Nodes.Interfaces;

namespace Premonition.Nodes.Abstractions
{
    [GlobalClass]
    public partial class Threshold : Area3D, IThreshold
    {
        private GameDirector Director { get => this.GetGameDirector(); }
        public Threshold(Node3D target)
        {
            Target = target;
        }

        public Node3D Target { get; private set; }

        public void OnThresholdEnter(Node3D body)
        {
            $"Body {body.Name} entered threshold".ToConsole();
            Target.Visible = true;
        }

        public void OnThresholdExit(Node3D body)
        {
            $"Body {body.Name} exited threshold".ToConsole();
            Target.Visible = false;
        }
    }
}