using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        public static int RouteStoryCounter { get; set; }
        public int DifficultyLevel { get; set; }
        public List<Node> RemovedItems { get; set; } = [];
        public override void _Ready()
        {
            base._Ready();
    
            DifficultyLevel = GD.RandRange(15, 20);
            $"Difficulty level is: {DifficultyLevel}".ToConsole();
        }
        private void RemoveRandomObject()
        {
            $"Difficulty level is: {DifficultyLevel}".ToConsole();
            double d20 = GD.RandRange(1, 20);
            bool skillCheck = d20 <= DifficultyLevel;
            if (skillCheck) // skill check
            {
                var children = GetChildren().Where(x => x is Item).ToList();
                $"Skill check failed with number {d20}".ToConsole();
                ChangeSkyLighting(Route0.SkyLightingMode.Darker);
                ;
                EmitSignal(SignalName.StoryProgressTriggered);
                RouteStoryCounter = GD.RandRange(0, 5); 
                if (children.ElementAtOrDefault(GD.RandRange(1, children.Count)) != null)
                {
                    RemoveChild(children.ElementAtOrDefault(GD.RandRange(1, children.Count)));
                    Director.ScreenManager.DebugPanel.AddProperty("\n\n", "Something happened. But I have calm on my mind.", 1);
                }
                else
                {
                    DirectionalLight3D light1 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D");
                    Hue1 = GetTree().CreateTween();
                    Hue1.BindNode(light1);
                    Start1 = light1.LightColor;
                    Color end1 = new Color(0.0f, 0.0f, 0.0f); // #66400D

                    DirectionalLight3D light2 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D5");
                    Hue2 = GetTree().CreateTween();
                    Hue2.BindNode(light2);
                    Start2 = light2.LightColor;
                    Color end2 = new Color(0.0f, 0.0f, 0.0f);

                    Hue1.TweenProperty(light1, "light_color", end1, CycleDuration * CycleMultiplier);
                    Hue1.SetParallel(true);
                    Hue2.TweenProperty(light2, "light_color", end2, CycleDuration * CycleMultiplier);
                    Director.ScreenManager.DebugPanel.AddProperty("The calm was on your mind.", "The storm was outside all along.", 0);
                }
                  
            }
            else
            {
                ChangeSkyLighting(Route0.SkyLightingMode.Lighter);
                $"Skill check passed with number {d20}. Continuing...".ToConsole();
            }
            
        }

        public void ListenToObjectRemoval()
        {
            Callable c = new Callable(this, MethodName.RemoveRandomObject);
            c.CallDeferred();
        }

        public static List<Color> StormColors =
        [
            new Color(0.44f, 0.63f, 0.89f), // #2C3F59
            new Color(0.20f, 0.28f, 0.38f), // #141C26
            new Color(0.88f, 0.122f, 0.166f), // #587AA6
            new Color(0.167f, 0.189f, 0.217f), // #A7BDD9
            new Color(0.38f, 0.106f, 0.166f) // #266AA6
        ];

        public static List<Color> CalmColors =
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

        private Tween Hue1 { get; set; }

        private Tween Hue2 { get; set; }
        private Color Start1 { get; set; }
        private Color Start2 { get; set; }
        private readonly float CycleDuration = (float)GD.RandRange(10.0, 30.0);
        private readonly float CycleMultiplier = (float)GD.RandRange(1.0, 3.0);

        public void ChangeSkyLighting(SkyLightingMode s)
        {
            switch (s)
            {
                case SkyLightingMode.Darker:
                    TweenHue1Dark();
                    TweenHue2Dark();
                    break;
                case SkyLightingMode.Lighter:
                    DirectionalLight3D light1 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D");
                    Hue1 = GetTree().CreateTween();
                    Hue1.BindNode(light1);
                    Start1 = light1.LightColor;
                    Color end1 = CalmColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)); // #66400D

                    DirectionalLight3D light2 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D5");
                    Hue2 = GetTree().CreateTween();
                    Hue2.BindNode(light2);
                    Start2 = light2.LightColor;
                    Color end2 = StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)); // #384359                    

                    Hue1.TweenProperty(light1, "light_color", end1, CycleDuration * CycleMultiplier);
                    Hue1.SetParallel(true);
                    Hue2.TweenProperty(light2, "light_color", end2, CycleDuration * CycleMultiplier);
                    Hue1.Finished += Hue1Light_Finished;
                    Hue2.Finished += Hue2Light_Finished;
                    break;
                default:
                    TweenHue1Dark();
                    TweenHue2Dark();
                    break;

            }

            

            //DirectionalLight3D light1 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D");
            //Tween Hue1 = GetTree().CreateTween();
            //Hue1.BindNode(light1);
            //Start1 = light1.LightColor;
            //Color end1 = new(0.102f, 0.64f, 0.13f, 1.0f); // #66400D
            //Hue1.TweenProperty(light1, "light_color", end1, CycleDuration * CycleMultiplier);
            //Hue1.SetParallel(true);
            //Hue1.Finished += Hue1_Finished;
        }
        private void TweenHue1Dark()
        {
            //Hue1 = Director.ScreenManager.ChangeLightingColorA(new Color(0.102f, 0.64f, 0.13f, 1.0f), CycleDuration * CycleMultiplier, out Color startA);
            //Start1 = startA;

            DirectionalLight3D light1 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D");
            Hue1 = GetTree().CreateTween();
            Hue1.BindNode(light1);
            Start1 = light1.LightColor;
            Color end1 = StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)); // #66400D
            Hue1.TweenProperty(light1, "light_color", end1, CycleDuration * CycleMultiplier);
            Hue1.SetParallel(true);
            Hue1.Finished += Hue1_Finished;
        }

        private void TweenHue2Dark()
        {
            //Hue2 = Director.ScreenManager.ChangeLightingColorB(new Color(0.56f, 0.67f, 0.89f, 1.0f), CycleDuration * CycleMultiplier, out Color startB);
            //Start2 = startB;
            DirectionalLight3D light2 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D5");
            Hue2 = GetTree().CreateTween();
            Hue2.BindNode(light2);
            Start2 = light2.LightColor;
            Color end2 = StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)); // #384359
            Hue2.TweenProperty(light2, "light_color", end2, CycleDuration * CycleMultiplier);
            Hue2.Finished += Hue2_Finished;
        }

        private void Hue1_Finished()
        {
            //Hue1 = Director.ScreenManager.ChangeLightingColorA(Start1, CycleDuration * CycleMultiplier, out _);
            DirectionalLight3D light1 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D");
            Hue1 = GetTree().CreateTween();
            Hue1.BindNode(light1);
            Hue1.TweenProperty(light1, "light_color", StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)), CycleDuration * CycleMultiplier);
            Hue1.Finished += TweenHue1Dark;
        }

        private void Hue2_Finished()
        {
            DirectionalLight3D light2 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D5");
            Hue2 = GetTree().CreateTween();
            Hue2.BindNode(light2);
            Hue2.TweenProperty(light2, "light_color", StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)), CycleDuration * CycleMultiplier);
            Hue2.Finished += TweenHue2Dark;
        }

        private void Hue1Light_Finished()
        {
            //Hue1 = Director.ScreenManager.ChangeLightingColorA(Start1, CycleDuration * CycleMultiplier, out _);
            DirectionalLight3D light1 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D");
            Hue1 = GetTree().CreateTween();
            Hue1.BindNode(light1);
            Hue1.TweenProperty(light1, "light_color", CalmColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)), CycleDuration * CycleMultiplier);
            Hue1.Finished += TweenHue1Dark;
        }

        private void Hue2Light_Finished()
        {
            DirectionalLight3D light2 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D5");
            Hue2 = GetTree().CreateTween();
            Hue2.BindNode(light2);
            Hue2.TweenProperty(light2, "light_color", CalmColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count)), CycleDuration * CycleMultiplier);
            Hue2.Finished += TweenHue2Dark;
        }

        //public void ChangeSkyLighting(SkyLightingMode mode) => this.GetGameDirector()
        //    .ScreenManager
        //    .ChangeLightingColorAll(
        //        mode == SkyLightingMode.Darker
        //            ? StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count))
        //            : CalmColors.ElementAtOrDefault(GD.RandRange(0, CalmColors.Count)),
        //        mode == SkyLightingMode.Darker
        //            ? StormColors.ElementAtOrDefault(GD.RandRange(0, StormColors.Count))
        //            : CalmColors.ElementAtOrDefault(GD.RandRange(0, CalmColors.Count)),
        //        (float)GD.RandRange(0.0, 5.0f),
        //        out _, // old color A
        //        out _  // old color B
        //    );

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