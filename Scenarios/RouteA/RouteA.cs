using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;

namespace Premonition.Scenarios.RouteA
{
    public sealed partial class RouteA : Scenario
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
        

        protected override void LoadResources()
        {
            _director.SceneManager.CurrentStoryline = 1;
        }
        
        public override void _Ready()
        {

        }
    }
}