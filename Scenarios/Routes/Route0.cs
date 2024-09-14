using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;

namespace Premonition.Scenarios.Routes
{
    /// <summary>
    /// never knew or never could know what happened, or if I even know if I'm in the storm
    /// the alzheimer's route
    /// </summary>
    public sealed partial class Route0 : Scenario
    {
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

        protected override void LoadResources()
        {
            Director.SceneManager.CurrentStoryline = 0;
            Director.ScreenManager.AddPlayer("res://Camera/Character.tscn".InstantiatePathAsScene(), out var player);
            player.GlobalPosition = GetNode<Marker3D>("PlayerPosition").GlobalPosition;
            if (this.Players != null) $"Player loaded: {this.Players.Count}".ToConsole(); else $"No players loaded".ToConsole();
        }
    }
}