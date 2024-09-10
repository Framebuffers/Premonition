using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;
using Premonition.Nodes.Interfaces;


namespace Premonition.Debug.Room03
{
	public partial class Main : Scenario
	{
		private IThreshold BathroomThreshold;
		protected override void LoadResources()
		{
			Players.Add("res://addons/fpc/character.tscn".InstantiatePathAsScene());
			BathroomThreshold = new Threshold(GetNode<MeshInstance3D>("S00003_A"));
		}

		private void OnThresholdEnter(Node3D body)
		{
			BathroomThreshold.OnThresholdEnter(body);
		}

		private void OnThresholdExit(Node3D body)
		{
			BathroomThreshold.OnThresholdExit(body);
		}
	}
}
