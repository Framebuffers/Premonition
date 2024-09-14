using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;

namespace Premonition.Nodes.Abstractions
{
    public abstract partial class Route : Scenario

    {
        protected GameDirector _director { get => this.GetGameDirector(); }
        protected string LightingPath = $"Environment/Lighting";
        protected Node3D Lighting { get => GetNode<Node3D>(LightingPath); }
        protected string TransitionsPath = $"Environment/Transitions";
        protected Node3D Transitions { get => GetNode<Node3D>(TransitionsPath); }
        protected string ColissionsPath = $"Environment/Colissions";
        protected Node3D Colisions { get => GetNode<Node3D>(ColissionsPath); }
        protected string MeshesPath = $"Environment/Meshes";

        protected Node3D Meshes { get => GetNode<Node3D>(MeshesPath); }
        protected const string PlayerPath = $"/root/ScreenManager/ScreenContainer/Screen3D/Players/Character";
        protected CharacterBody3D PlayerBody { get => GetNode<CharacterBody3D>(PlayerPath); }
        protected Camera3D Camera { get => GetNode<Camera3D>("/root/ScreenManager/ScreenContainer/Screen3D/Players/Character/Head/Camera"); }
        protected MeshInstance3D Shader { get => GetNode<MeshInstance3D>("/root/ScreenManager/ScreenContainer/Screen3D/Players/Character/Head/Camera/MeshInstance3D"); }

        protected void OnStaircaseEnter(Node node)
		{
			Node3D body = node as Node3D;
			var position = body.Position;
			position.Y += 2.5f;
		}

		protected void OnStaircaseExit(Node node)
		{
			Node3D body = node as Node3D;
			var position = body.Position;
			position.Y -= 2.5f;
		}
        
    
    }
}