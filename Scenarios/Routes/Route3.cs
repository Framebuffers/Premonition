using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;

namespace Premonition.Scenarios.Routes
{
    /// <summary>
    /// my peace was interrupted by a sudden event, while preparing something for someone that will never come
    /// the lost person route
    /// </summary>
    public sealed partial class Route3 : Scenario
    {


        protected override void LoadResources()
        {
            Director.SceneManager.CurrentStoryline = 3;
            Director.ScreenManager.AddPlayer("res://Camera/Character.tscn".InstantiatePathAsScene(), out var player);
            player.GlobalPosition = GetNode<Marker3D>("PlayerPosition").GlobalPosition;
            if (this.Players != null) $"Player loaded: {this.Players.Count}".ToConsole(); else $"No players loaded".ToConsole();

        }
    }
}