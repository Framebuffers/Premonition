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
			Players.Add(PlayerPaths.Placeholder.InstantiatePathAsScene());
	
		}


	}
}
