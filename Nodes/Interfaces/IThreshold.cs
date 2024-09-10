using Godot;

namespace Premonition.Nodes.Interfaces
{
    public interface IThreshold
    {
        void OnThresholdEnter(Node3D body);
        void OnThresholdExit(Node3D body);
    }
}