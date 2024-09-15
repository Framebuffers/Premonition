using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;
using System.Linq;
using System.Runtime.InteropServices;

namespace Premonition.Scenarios.Routes
{
    /// <summary>
    /// never knew or never could know what happened, or if I even know if I'm in the storm
    /// the alzheimer's route
    /// </summary>
    public sealed partial class Route0 : Scenario
    {
        [Signal]
        public delegate void ListenerEventHandler();

        public override void _Ready()
        {
            base._Ready();
        }

        private void ListenToObjectRemoval()
        {
            var list = GetNode<Node3D>("/root/GameDirector/ScreenManager/ScreenContainer/Screen3D/Route0").GetChildren().Where(x => x is Item);
            var count = list.Count();
            //Director.ScreenManager.RemoveFromScreen3D(list[GD.RandRange(0, list.Count)]);
            $"Selected item: {list.ElementAt(GD.RandRange(0, count))}".ToConsole();
        }

        // things to do:
        // 1. account for loops in music
        // 2. account for progressions in plot:
        //      a. use key items
        //      b. either push text from here or directly edit the caller class.
        // 3. randomise the plot.
        // 
        // how?
        // 1. use body_entered as a metric for plot progression.
        // 2. queue a track loop when something happens.

        protected override void LoadResources()
        {
            Director.ScreenManager.AddPlayer("res://Camera/Character.tscn".InstantiatePathAsScene(), out var player);
            player.GlobalPosition = GetNode<Marker3D>("PlayerPosition").GlobalPosition;
            if (this.Players != null) $"Player loaded: {this.Players.Count}".ToConsole(); else $"No players loaded".ToConsole();
            Director.SceneManager.CurrentStoryline = 0;

        }
    }
}