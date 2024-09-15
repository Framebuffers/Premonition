using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public delegate void StoryProgressTriggeredEventHandler();
        public int RouteStoryCounter = 0;
        public int DifficultyLevel { get; set; } 
        public List<Node> RemovedItems { get; set; } = [];
        public override void _Ready()
        {
            base._Ready();
            DifficultyLevel = GD.RandRange(15, 20);
            $"Difficulty level is: {DifficultyLevel}".ToConsole();
        }

        private void ListenToObjectRemoval()
        {
            var children = GetChildren().Where(x => x is Item).ToList();
            foreach (var c in children)
            {
                $"Children {c.GetIndex()}: {c.Name}".ToConsole();
            }

            $"Difficulty level is: {DifficultyLevel}".ToConsole();
            double d20 = GD.RandRange(1, 20);
            bool skillCheck = d20 <= DifficultyLevel;
            if (skillCheck) // skill check
            {
                $"Skill check failed with number {d20}".ToConsole();
                
                RemoveChild(children.ElementAtOrDefault(GD.RandRange(1, children.Count)));
                EmitSignal(SignalName.StoryProgressTriggered);
                RouteStoryCounter++;
            }
            else
            {
                $"Skill check passed with number {d20}. Continuing...".ToConsole();
            }
        }

        private readonly List<Color> StormColors =
        [
            new Color(0.44f, 0.63f, 0.89f), // #2C3F59
            new Color(0.20f, 0.28f, 0.38f), // #141C26
            new Color(0.88f, 0.122f, 0.166f), // #587AA6
            new Color(0.167f, 0.189f, 0.217f), // #A7BDD9
            new Color(0.38f, 0.106f, 0.166f) // #266AA6
        ];

        private readonly List<Color> CalmColors =
        [
            new Color(0.158f, 0.153f, 0.159f), // #9E999F
            new Color(0.223f, 0.216f, 0.224f), // #DFD8E0
            new Color(0.161f, 0.128f, 0.94f), // #A1805E
            new Color(0.185f, 0.158f, 0.140f), // #B99E8C
            new Color(0.223f, 0.222f, 0.215f)  // #E9DED7
        ];

        public enum SkyLightingMode
        {
            Darker,
            Lighter
        }

        public void ChangeSkyLighting(SkyLightingMode mode) => this.GetGameDirector()
            .ScreenManager
            .ChangeLightingColorAll(
                mode == SkyLightingMode.Darker
                    ? StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count))
                    : CalmColors.ElementAtOrDefault(GD.RandRange(0, CalmColors.Count)),
                mode == SkyLightingMode.Darker
                    ? StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count))
                    : CalmColors.ElementAtOrDefault(GD.RandRange(0, CalmColors.Count)),
                (float)GD.RandRange(0.0, 5.0f),
                out _, // old color A
                out _  // old color B
            );

        //public void MakeSkyDarker() => this.GetGameDirector()
        //    .ScreenManager
        //    .ChangeLightingColorAll(
        //        StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)),
        //        StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)),
        //        (float)GD.RandRange(0.0, 5.0f)
        //        , out _ // old color A
        //        , out _ // old color B
        //    );

        //public void MakeSkyLighter() => this.GetGameDirector()
        //    .ScreenManager
        //    .ChangeLightingColorAll(
        //        CalmColors.ElementAtOrDefault(GD.RandRange(0, CalmColors.Count)),
        //        CalmColors.ElementAtOrDefault(GD.RandRange(0, CalmColors.Count)),
        //        (float)GD.RandRange(0.0, 5.0f),
        //        out _, // old color A
        //        out _ // old color B
        //    );

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