using Godot;
using Premonition.Managers;
using System.Collections.Generic;

namespace Premonition.Nodes.Abstractions
{
    public abstract partial class Scenario : Node3D
    {
        protected GameDirector Director { get => this.GetGameDirector(); }

        // Players must be unique so no duplicate cameras are instantiated.
        public HashSet<Node> Players { get; set; } = new HashSet<Node>();
        public override void _Ready()
        {
            base._Ready();
            CallDeferred(MethodName.LoadResources);
            //LoadPlayers();
        }

        protected void LoadPlayers()
        {

        }

        protected abstract void LoadResources();

        protected void OnStaircaseEnter(Node node)
        {
            Node3D body = node as Node3D;
            var position = body.Position;
            position.Y += 2.5f;
        }
        protected void OnStaircaseExit(Node node)
        {
            Node3D body = node as Node3D;
            var position = body.Position;
            position.Y -= 2.5f;
        }
    }
}