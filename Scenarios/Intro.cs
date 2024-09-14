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
        private GameDirector _director { get => this.GetGameDirector(); }
        private const string LightingPath = "/root/ScreenManager/ScreenContainer/Screen3D/Route1/Environment/Lighting";
        private Node3D Lighting { get => GetNode<Node3D>(LightingPath); }
        private const string TransitionsPath = "/root/ScreenManager/ScreenContainer/Screen3D/Route1/Environment/Transitions";
        private Node3D Transitions { get => GetNode<Node3D>(TransitionsPath); }
        private const string ColissionsPath = "/root/ScreenManager/ScreenContainer/Screen3D/Route1/Environment/Colissions";
        private Node3D Colisions { get => GetNode<Node3D>(ColissionsPath); }
        private const string MeshesPath = "/root/ScreenManager/ScreenContainer/Screen3D/Route1/Environment/Meshes";
        private Node3D Meshes { get => GetNode<Node3D>(MeshesPath); }
        private const string PlayerPath = "/root/ScreenManager/ScreenContainer/Screen3D/Players/Character";
        private CharacterBody3D PlayerBody { get => GetNode<CharacterBody3D>(PlayerPath); }
        private Camera3D Camera { get => GetNode<Camera3D>("/root/ScreenManager/ScreenContainer/Screen3D/Players/Character/Head/Camera"); }
        private MeshInstance3D Shader { get => GetNode<MeshInstance3D>("/root/ScreenManager/ScreenContainer/Screen3D/Players/Character/Head/Camera/MeshInstance3D"); }


        // private void OnStaircaseEnter(Node node)
        // {
        // 	Node3D body = node as Node3D;
        // 	var position = body.Position;
        // 	position.Y += 2.5f;
        // }

        // private void OnStaircaseExit(Node node)
        // {
        // 	Node3D body = node as Node3D;
        // 	var position = body.Position;
        // 	position.Y -= 2.5f;
        // }

        private Tween _tween { get; set; }

        private void MoveLights()
        {
            _tween = GetTree().CreateTween();
            _tween.BindNode(GetNode<Node3D>("Environment/Lighting"));
            _tween.TweenProperty(GetNode<Node3D>("Environment/Lighting"), "rotation_degrees", new Vector3(0.0f, 360.0f, 0.0f), 20.0f);
            _tween.Finished += OnTweenCompleted;
        }

        private void OnTweenCompleted()
        {
            GetNode<Node3D>("Environment/Lighting").RotationDegrees = Vector3.Zero;
            MoveLights();
        }

        protected override void LoadResources()
        {
            // Load player in the living room.
            // Director.ScreenManager.AddPlayer("res://Camera/Character.tscn".InstantiatePathAsScene(), out _);
            Input.MouseMode = Input.MouseModeEnum.Confined;
            MoveLights();
            // _director.ScreenManager.UserInterface.AddChild("res://Scenarios/UI/Start.tscn".InstantiatePathAsScene());

            // set up UI stuff.
            // Hook buttons
            // On start, load a random scene.

            // if (this.Players != null) $"Player loaded: {this.Players.Count}".ToConsole(); else $"No players loaded".ToConsole();
        }

    }
}