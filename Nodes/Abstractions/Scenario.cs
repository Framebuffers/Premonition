using System.Collections.Generic;
using Godot;
using Premonition.Managers;

namespace Premonition.Nodes.Abstractions
{
    public abstract partial class Scenario : Node3D
    {
        protected GameDirector Director { get => this.GetGameDirector(); }
  
        // Players must be unique so no duplicate cameras are instantiated.
        public HashSet<Node> Players { get; set; } = new HashSet<Node>();
        public override void _Ready()
        {
            LoadResources();
            LoadPlayers();
        }

        protected void LoadPlayers()
        {
            foreach (var player in Players)
            {
                Director.SceneManager.LoadPlayer(player);
            }
        }

        protected abstract void LoadResources();
    }
}