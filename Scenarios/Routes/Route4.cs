using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;

namespace Premonition.Scenarios.Routes
{
    /// <summary>
    /// my peace was enjoying myself, and then the storm came when I entered my home and realised what happened.
    /// the "in the air tonight" route
    /// </summary>
    public sealed partial class Route4 : Scenario
    {


        protected override void LoadResources()
        {
            Director.SceneManager.CurrentStoryline = 4;
            Director.ScreenManager.AddPlayer("res://Camera/Character.tscn".InstantiatePathAsScene(), out var player);
            player.GlobalPosition = GetNode<Marker3D>("PlayerPosition").GlobalPosition;
            if (this.Players != null) $"Player loaded: {this.Players.Count}".ToConsole(); else $"No players loaded".ToConsole();

        }
    }
}