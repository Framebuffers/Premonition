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

        public override void _Ready()
        {
            base._Ready();
            
        }

        private async void ListenToObjectRemoval()
        {
            await ToSignal(GetTree(), Item.SignalName.ObjectHiding);
            var list = Director.ScreenManager.Screen3D.GetChildren().OfType<Item>();
            var count = list.Count();
            //Director.ScreenManager.RemoveFromScreen3D(list[GD.RandRange(0, list.Count)]);
            $"Selected item: {list.ElementAt(GD.RandRange(0, count))}".ToConsole();
        }

        protected override void LoadResources()
        {
            Director.ScreenManager.AddPlayer("res://Camera/Character.tscn".InstantiatePathAsScene(), out var player);
            player.GlobalPosition = GetNode<Marker3D>("PlayerPosition").GlobalPosition;
            if (this.Players != null) $"Player loaded: {this.Players.Count}".ToConsole(); else $"No players loaded".ToConsole();
            Director.SceneManager.CurrentStoryline = 0;

        }
    }
}