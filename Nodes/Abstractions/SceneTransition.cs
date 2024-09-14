using Godot;
using Premonition.Managers;
using Premonition.Nodes.Interfaces;

namespace Premonition.Nodes.Abstractions
{
    public partial class SceneTransition : Area3D, ITransition
    {
        private GameDirector Director { get => this.GetGameDirector(); }
        public SceneTransition(string targetScene) => TargetScene = targetScene;


        public string TargetScene { get; set; }

        public Node3D? BodyEntering { get; set; }

        public void OnSceneTransition(Node3D body)
        {
            BodyEntering = body;
            Director.SceneManager.LoadScene(TargetScene);
        }
    }
}