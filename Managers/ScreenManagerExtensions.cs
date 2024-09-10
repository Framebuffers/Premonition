using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premonition.Managers
{
	/// <summary>
	/// Extension methods to instantiate and manage any Nodes coming and going through the screen.
	/// </summary>
	public static partial class ScreenManagerExtensions
	{
		// oh shit this one is dangerous, it will throw an exception if the path does not cast to PackedScene.
		// 2024-09-06: lmao dummy it's safe af. nothing happened for months.

		/// <summary>
		/// Takes a path to a node as a string, casts to PackedScene, instantiates it and returns it as Node.
		/// Throws an exception if type is not PackedScene.
		/// </summary>
		/// <param name="scenePath">Absolute path to a PackedScene.</param>
		/// <returns>An instantiated Node object with all the scene's objects as children of it.</returns>
		public static Node InstantiatePathAsScene(this string scenePath)
		{
			try
			{
				return GD.Load<PackedScene>(scenePath).Instantiate();
			}
			catch (Exception e)
			{
				$"Exception caught at: {e.TargetSite}\n \t{e.Message}\n \t{e.StackTrace}\n".ToConsoleAsException();
			}
			return null;
		}

		/// <summary>
		/// Instantiates a scene to Screen3D by it's path string.
		/// </summary>
		public static void AddSceneToScreen3D(this ScreenManager screenManager, string pathToScene) => screenManager.Screen3D.AddChild(pathToScene.InstantiatePathAsScene());

		public static void AddSceneToScreen3D(this ScreenManager screenManager, SceneManager scnMan, Node n)
		{
			screenManager.Screen3D.AddChild(n);
			scnMan.CurrentScene = n;
		}

		public static void AddSceneToScreen3D<T>(this ScreenManager screenManager, T n) where T : Node
		{
			screenManager.AddToScreen3D(n);
		}

		/// <summary>
		/// Instantiates a scene to the top of Screen3D by it's path string.
		/// </summary>
		public static void AddSceneToTopOfScreen3D(this ScreenManager screenManager, string pathToScene)
		{
			var scene = pathToScene.InstantiatePathAsScene();
			screenManager.AddNodeToScreen3D(scene);
			screenManager.Screen3D.MoveChild(scene, 0);
		}

		/// <summary>
		/// Instantiates a scene to the top of Screen3D by it's path string. Returns the object created as out parameter.
		/// </summary>
		public static void AddSceneToTopOfScreen3D(this ScreenManager screenManager, string pathToScene, out Node topNode)
		{
			var scene = pathToScene.InstantiatePathAsScene();
			screenManager.AddToScreen3D(scene);
			topNode = scene;
		}

		/// <summary>
		/// Adds a node to the top of Screen3D.
		/// </summary>
		public static void AddNodeToScreen3D(this ScreenManager screenManager, Node n)
		{
			screenManager.AddToScreen3D(n);
			screenManager.Screen3D.MoveChild(n, 0);
		}

		/// <summary>
		/// Adds a Node to Screen3D. Any object deriving from Godot.Node can be added.
		/// </summary>
		public static void AddToScreen3D<T>(this ScreenManager screenManager, T n) where T : Node => screenManager.Screen3D.AddChild(n);

		public static void AddSceneToScreen3D(this ScreenManager screenManager, string nodePath, out Node sceneAdded)
		{
			$"Loading scene...".ToConsole();
			var scene = nodePath.InstantiatePathAsScene();
			screenManager.AddToScreen3D(scene);
			sceneAdded = scene;
		}

		public static void LoadScene(this ScreenManager screenManager, SceneManager scnMan, string scenePath)
		{
			Node scene = scenePath.InstantiatePathAsScene();

			$"Removing scene from screen...".ToConsole();
			if (scnMan.CurrentScene != null) screenManager.Screen3D.RemoveChild(scnMan.CurrentScene);

			$"Clearing CurrentScene from SceneManager...".ToConsole();
			scnMan.CurrentScene = null;

			$"Loading scene...".ToConsole();
			screenManager.AddToScreen3D(scene);

			$"Loading scene to SceneManager...".ToConsole();
			scnMan.CurrentScene = scene;
		}

		/// <summary>
		/// Adds a new Player to the Screen3D/Players Node. Instantiates a CharacterBody3D from a string path, checks if it exists already
		/// on the Node, and adds it. If the Node already contains this instance, it won't be added and outputs the same character to addedPlayer.
		/// If 
		/// </summary>
		/// <param name="screenManager">ScreenManager containing the Screen3D SubViewport.</param>
		/// <param name="playerScenePath">Path to a PackedScene with a CharacterBody3D as root node.</param>
		/// <param name="addedPlayer">Instance of the Player added to the screen.</param>
		public static void AddPlayerToScreen3D(this ScreenManager screenManager, string playerScenePath, out CharacterBody3D addedPlayer)
		{
			Node players = screenManager.PlayersOnScreen;
			CharacterBody3D? character = playerScenePath.InstantiatePathAsScene() as CharacterBody3D;

			// Is there anything on the Player node?
			switch (screenManager.PlayersOnScreen3D())
			{
				// Skip loading and poss the instance to to addedPlayer.
				case true:
					$"{character.Name} is already loaded. Skipping...".ToConsole();
					addedPlayer = character;
					return;
				case false:
					// We add the Player to the Node and return the same instance to addedPlayer.
					$"No players loaded, adding new player to screen...".ToConsole();
					players.AddChild(character);
					addedPlayer = character;
					return;
			}
		}

		public static void AddPlayerToScreen3D(this ScreenManager screenManager, Node playerScene, out CharacterBody3D addedPlayer)
		{
			Node players = screenManager.PlayersOnScreen;
			CharacterBody3D character = playerScene as CharacterBody3D;

			// Is there anything on the Player node?
			switch (screenManager.PlayersOnScreen3D())
			{
				// Skip loading and poss the instance to to addedPlayer.
				case true:
					$"{character.Name} is already loaded. Skipping...".ToConsole();
					addedPlayer = character;
					return;
				case false:
					// We add the Player to the Node and return the same instance to addedPlayer.
					$"No players loaded, adding new player to screen...".ToConsole();
					players.AddChild(character);
					addedPlayer = character;
					return;
			}
		}

		public static void RemoveCurrentSceneFromScreen3D(this ScreenManager screenManager, SceneManager scnMan)
		{
			$"\nRemoving scene from screen...".ToConsole();
			if (scnMan.CurrentScene is not null)
			{
				screenManager.Screen3D.RemoveChild(scnMan.CurrentScene);
				$"\tClearing CurrentScene from SceneManager...".ToConsole();
				scnMan.CurrentScene = null;
			}
		}

		public static void RemoveSceneFromScreen3D(this ScreenManager screenManager, Node sceneToRemove)
		{
			$"\nRemoving scene from screen...".ToConsole();
			screenManager.Screen3D.RemoveChild(sceneToRemove);
		}


		/// <summary>
		/// Checks if there's any player currently on the screen.
		/// </summary>
		/// <param name="screenManager"></param>
		/// <returns>True if any CharacterBody3D is loaded. False if no CharacterBody3D is loaded, regardless if any other object is loaded.</returns>
		public static bool PlayersOnScreen3D(this ScreenManager screenManager) => screenManager.PlayersOnScreen.GetChildren().OfType<CharacterBody3D>().Any();

		/// <summary>
		/// Checks if there's a particular character on the screen.
		/// </summary>
		/// <param name="screenManager"></param>
		/// <param name="player">Player to check for.</param>
		/// <returns>True if it's already loaded, false if not.</returns>
		public static bool PlayerOnScreen3D(this ScreenManager screenManager, CharacterBody3D player) => screenManager.PlayersOnScreen.GetChildren().Contains(player);

		/// <summary>
		/// Checks if there's any Scenario loaded on the screen. Checks for any object deriving from TwoTribes.Scenes.Abstractions.Scenario, a Node3D with provisions for containing game scenarios.
		/// </summary>
		/// <param name="screenManager"></param>
		/// <returns>True if any Scenario is loaded on the screen, false if not.</returns>
		public static bool ScenarioOnScreen3D(this ScreenManager screenManager) => screenManager.Screen3D.GetChildren().OfType<Scenario>().Any();



	}

    internal partial class Scenario : Node3D
    {
    }

}
