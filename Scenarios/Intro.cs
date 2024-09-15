using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;

namespace Premonition.Scenarios.Routes
{
    /// <summary>
    /// never knew or never could know what happened, or if I even know if I'm in the storm
    /// </summary>
    public sealed partial class Intro : Scenario
    {
     
        private Tween Piano { get; set; }
        private Tween Pots { get; set; }
        private Tween Lights { get; set; }
        private Tween Hue1 { get; set; }

        private Tween Hue2 { get; set; }
        private Color Start1 { get; set; }
        private Color Start2 { get; set; }
        private readonly float CycleDuration = (float)GD.RandRange(10.0, 30.0);
        private readonly float CycleMultiplier = (float)GD.RandRange(1.0, 3.0);

        protected override void LoadResources()
        {
            Input.MouseMode = Input.MouseModeEnum.Confined;
            $"Intro screen tween cycle is: {CycleDuration}".ToConsole();
            MoveLights();
            MovePiano();
            MovePots();
            TweenHue1();
            TweenHue2();
        }


        // lights
        private void MoveLights()
        {
            Lights = GetTree().CreateTween();
            Lights.BindNode(GetNode<Node3D>("Environment/Lighting"));
            Lights.TweenProperty(GetNode<Node3D>("Environment/Lighting"), "rotation_degrees", new Vector3(0.0f, 360.0f, 0.0f), CycleDuration);
            Lights.SetParallel(true);

            Lights.Finished += OnLightingTweenCompleted;
        }

        private void OnLightingTweenCompleted()
        {
            GetNode<Node3D>("Environment/Lighting").RotationDegrees = Vector3.Zero;
            MoveLights();
        }

        // piano
        private void MovePiano()
        {
            Piano = GetTree().CreateTween();
            Piano.BindNode(GetNode<Node3D>("Piano"));
            Piano.TweenProperty(GetNode<Node3D>("Piano"), "position", new Vector3(0.0f, 0.0f, 2.0f), CycleDuration).AsRelative();
            Piano.SetParallel(true);
            Piano.TweenProperty(GetNode<Node3D>("Piano"), "rotation_degrees", new Vector3(0.0f, 0.0f, -28.5f), CycleDuration).AsRelative();
            Piano.Finished += OnPianoTweenCompleted;
        }

        private void OnPianoTweenCompleted()
        {
            Piano = GetTree().CreateTween();
            Piano.BindNode(GetNode<Node3D>("Piano"));
            Piano.TweenProperty(GetNode<Node3D>("Piano"), "position", new Vector3(0.0f, 0.0f, -2.0f), CycleDuration * CycleMultiplier).AsRelative();
            Piano.TweenProperty(GetNode<Node3D>("Piano"), "rotation_degrees", new Vector3(0.0f, 0.0f, -4.7f), CycleDuration * CycleMultiplier).AsRelative();
            Piano.Finished += MovePiano;
        }

        // pots
        private void MovePots()
        {
            Pots = GetTree().CreateTween();
            Pots.BindNode(GetNode<Node3D>("PlantPot1"));
            Pots.TweenProperty(GetNode<Node3D>("PlantPot1"), "position", new Vector3(1.0f, 2.0f, 1.0f), CycleDuration).AsRelative();
            Pots.SetParallel(true);
            Pots.TweenProperty(GetNode<Node3D>("PlantPot1"), "rotation_degrees", new Vector3(0.0f, 0.0f, 25.0f), CycleDuration).AsRelative();
            Pots.Finished += OnPotsTweenCompleted;
        }

        private void OnPotsTweenCompleted()
        {
            Pots = GetTree().CreateTween();
            Pots.BindNode(GetNode<Node3D>("PlantPot1"));
            Pots.TweenProperty(GetNode<Node3D>("PlantPot1"), "position", new Vector3(-1.0f, -2.0f, -1.0f), CycleDuration * CycleMultiplier).AsRelative();
            Pots.SetParallel(true);
            Pots.TweenProperty(GetNode<Node3D>("PlantPot1"), "rotation_degrees", new Vector3(0.0f, 0.0f, -4.7f), CycleDuration * CycleMultiplier).AsRelative();
            Pots.Finished += MovePots;
        }

        // hue
        //private void TweenHue()
        //{
        //    DirectionalLight3D light1 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D");
        //    DirectionalLight3D light2 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D5");
        //    Hue1 = GetTree().CreateTween();
        //    Hue2 = GetTree().CreateTween();
        //    Hue1.BindNode(light1);
        //    Hue2.BindNode(light2);
        //    Start1 = light1.LightColor;
        //    Color end1 = new Color(0.28f, 0.9f, 0.217f, 1.0f); // #1C5AD9
        //    Start2 = light2.LightColor;
        //    Color end2 = new Color(0.56f, 0.67f, 0.89f, 1.0f); // #384359
        //    Hue1.TweenProperty(light1, "light_color", end1, CycleDuration);
        //    Hue1.SetParallel(true);
        //    Hue2.TweenProperty(light2, "light_color", end2, CycleDuration);
        //    Hue1.Finished += Hue1_Finished;
        //    Hue2.Finished += Hue2_Finished;
        //}

        private void TweenHue1()
        {
            //Hue1 = Director.ScreenManager.ChangeLightingColorA(new Color(0.102f, 0.64f, 0.13f, 1.0f), CycleDuration * CycleMultiplier, out Color startA);
            //Start1 = startA;

            DirectionalLight3D light1 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D");
            Hue1 = GetTree().CreateTween();
            Hue1.BindNode(light1);
            Start1 = light1.LightColor;
            Color end1 = new(0.102f, 0.64f, 0.13f, 1.0f); // #66400D
            Hue1.TweenProperty(light1, "light_color", end1, CycleDuration * CycleMultiplier);
            Hue1.SetParallel(true);
            Hue1.Finished += Hue1_Finished;
        }

        private void TweenHue2()
        {
            //Hue2 = Director.ScreenManager.ChangeLightingColorB(new Color(0.56f, 0.67f, 0.89f, 1.0f), CycleDuration * CycleMultiplier, out Color startB);
            //Start2 = startB;
            DirectionalLight3D light2 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D5");
            Hue2 = GetTree().CreateTween();
            Hue2.BindNode(light2);
            Start2 = light2.LightColor;
            Color end2 = new(0.56f, 0.67f, 0.89f, 1.0f); // #384359
            Hue2.TweenProperty(light2, "light_color", end2, CycleDuration * CycleMultiplier);
            Hue2.Finished += Hue2_Finished;
        }

        private void Hue1_Finished()
        {
            //Hue1 = Director.ScreenManager.ChangeLightingColorA(Start1, CycleDuration * CycleMultiplier, out _);
            DirectionalLight3D light1 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D");
            Hue1 = GetTree().CreateTween();
            Hue1.BindNode(light1);
            Hue1.TweenProperty(light1, "light_color", Start1, CycleDuration * CycleMultiplier);
            Hue1.Finished += TweenHue1;
        }

        private void Hue2_Finished()
        {
            DirectionalLight3D light2 = GetNode<DirectionalLight3D>("Environment/Lighting/DirectionalLight3D5");
            Hue2 = GetTree().CreateTween();
            Hue2.BindNode(light2);
            Hue2.TweenProperty(light2, "light_color", Start2, CycleDuration * CycleMultiplier);
            Hue2.Finished += TweenHue2;
        }


    }
}