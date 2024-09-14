using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;

namespace Premonition.Scenarios.Routes
{
    /// <summary>
    /// i caused the storm to come and destroy the peace
    /// the impulsivity route
    /// </summary>
    public sealed partial class Route2 : Route
    {
        protected override void LoadResources()
        {
            Director.SceneManager.CurrentStoryline = 2;
            Director.ScreenManager.AddPlayer("res://Camera/Character.tscn".InstantiatePathAsScene(), out var player);
            player.GlobalPosition = GetNode<Marker3D>("PlayerPosition").GlobalPosition;
            if (this.Players != null) $"Player loaded: {this.Players.Count}".ToConsole(); else $"No players loaded".ToConsole();
        }
    }
}