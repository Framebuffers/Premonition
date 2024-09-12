using Godot;
using Premonition.Managers;
using Premonition.Nodes.Abstractions;
using Premonition.Nodes.Interfaces;


namespace Premonition.Scenarios.LivingRoom
{
	public partial class Main : Scenario
	{
		
		protected override void LoadResources()
		{
			Players.Add("res://Camera/Character.tscn".InstantiatePathAsScene());
	
		}

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

	}
}
