using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;

namespace Premonition.Scenarios.Routes
{
    /// <summary>
    /// my peace was lost the day before, and I am slowly realising the storm that's brewing
    /// the party route
    /// </summary>
    public sealed partial class Route1 : Scenario
    {
        protected override void LoadResources()
        {
            Director.SceneManager.CurrentStoryline = 1;
            Director.ScreenManager.AddPlayer("res://Camera/Character.tscn".InstantiatePathAsScene(), out var player);
            player.GlobalPosition = GetNode<Marker3D>("PlayerPosition").GlobalPosition;
            if (this.Players != null) $"Player loaded: {this.Players.Count}".ToConsole(); else $"No players loaded".ToConsole();
        }
    }
}