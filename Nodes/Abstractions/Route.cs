using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;

namespace Premonition.Nodes.Abstractions
{
    public abstract partial class Route : Scenario
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
        protected abstract uint StorylineNumber { get; }

		private void OnStaircaseEnter(Node node)
		{
			Node3D body = node as Node3D;
			var position = body.Position;
			position.Y += 2.5f;
		}

		private void OnStaircaseExit(Node node)
		{
			Node3D body = node as Node3D;
			var position = body.Position;
			position.Y -= 2.5f;
		}

        protected override void LoadResources()
        {
             _director.SceneManager.CurrentStoryline = StorylineNumber;
            Director.ScreenManager.AddPlayer("res://Camera/Character.tscn".InstantiatePathAsScene(), out _);
            if (this.Players != null) $"Player loaded: {this.Players.Count}".ToConsole(); else $"No players loaded".ToConsole();
        }
    
    }
}