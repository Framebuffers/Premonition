using Godot;
using Premonition.Nodes.Abstractions;
using System;
using System.Linq;

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
                return null;
            }
        }

        public static void InstantiatePathAsScene<T>(this string scenePath, out T instance) where T : Node
        {
            try
            {
                Node n = GD.Load<PackedScene>(scenePath).Instantiate();
                instance = n as T ?? throw new ArgumentException(null, nameof(scenePath));
            }
            catch (Exception e)
            {
                $"Exception caught at: {e.TargetSite}\n \t{e.Message}\n \t{e.StackTrace}\n".ToConsoleAsException();
                instance = default!;
            }
        }

        /// <summary>
        /// Instantiates a scene to Screen3D by it's path string.
        /// </summary>
        public static void AddToScreen3D(this ScreenManager screenManager, string pathToScene)
        {
            screenManager.Screen3D.AddChild(pathToScene.InstantiatePathAsScene());
        }

        public static void AddToScreen3D(this ScreenManager screenManager, string pathToScene, out Node n)
        {
            var node = pathToScene.InstantiatePathAsScene();
            screenManager.Screen3D.AddChild(node);
            n = node;
        }

        public static void AddAsCurrentScene(this ScreenManager screenManager, SceneManager scnMan, Node n, out Node currentScene)
        {
            screenManager.Screen3D.AddChild(n);
            scnMan.CurrentScene = n;
            currentScene = n;
        }

        /// <summary>
        /// Instantiates a scene to the top of Screen3D by it's path string.
        /// </summary>
        public static void AddSceneToTopOfScreen3D(this ScreenManager screenManager, string pathToScene, out Node topNode)
        {
            var scene = pathToScene.InstantiatePathAsScene();
            screenManager.AddToScreen3D(scene);
            screenManager.Screen3D.MoveChild(scene, 0);
            topNode = scene;
        }


        /// <summary>
        /// Adds a Node to Screen3D. Any object deriving from Godot.Node can be added.
        /// </summary>
        public static void AddToScreen3D<T>(this ScreenManager screenManager, T n) where T : Node
        {
            screenManager.Screen3D.AddChild(n);
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
        public static void AddPlayer(this ScreenManager screenManager, string playerScenePath, out CharacterBody3D addedPlayer)
        {
            Node players = screenManager.PlayersOnScreen;
            CharacterBody3D character = playerScenePath.InstantiatePathAsScene() as CharacterBody3D;

            // Is there anything on the Player node?
            switch (screenManager.AreAnyPlayersLoaded())
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

        public static void AddPlayer(this ScreenManager screenManager, Node playerScene, out CharacterBody3D addedPlayer)
        {
            Node players = screenManager.PlayersOnScreen;
            CharacterBody3D character = playerScene as CharacterBody3D;

            // Is there anything on the Player node?
            switch (screenManager.AreAnyPlayersLoaded())
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

        public static void RemoveCurrentScene(this ScreenManager screenManager, SceneManager scnMan)
        {
            $"\nRemoving scene from screen...".ToConsole();
            if (scnMan.CurrentScene is not null)
            {
                screenManager.Screen3D.RemoveChild(scnMan.CurrentScene);
                $"\tClearing CurrentScene from SceneManager...".ToConsole();
                scnMan.CurrentScene = null;
            }
        }

        public static void RemoveFromScreen3D(this ScreenManager screenManager, Node nodeToRemove)
        {
            $"\nRemoving scene from screen...".ToConsole();
            screenManager.Screen3D.RemoveChild(nodeToRemove);
        }

        /// <summary>
        /// Checks if there's any player currently on the screen.
        /// </summary>
        /// <param name="screenManager"></param>
        /// <returns>True if any CharacterBody3D is loaded. False if no CharacterBody3D is loaded, regardless if any other object is loaded.</returns>
        public static bool AreAnyPlayersLoaded(this ScreenManager screenManager) => screenManager
                                                                                    .PlayersOnScreen.GetChildren()
                                                                                    .OfType<CharacterBody3D>()
                                                                                    .Any();

        /// <summary>
        /// Checks if there's a particular character on the screen.
        /// </summary>
        /// <param name="screenManager"></param>
        /// <param name="player">Player to check for.</param>
        /// <returns>True if it's already loaded, false if not.</returns>
        public static bool IsPlayerLoaded(this ScreenManager screenManager, CharacterBody3D player) => screenManager.PlayersOnScreen.GetChildren()
                                                                                                                              .Contains(player);

        /// <summary>
        /// Checks if there's any Scenario loaded on the screen. Checks for any object deriving from TwoTribes.Scenes.Abstractions.Scenario, a Node3D with provisions for containing game scenarios.
        /// </summary>
        /// <param name="screenManager"></param>
        /// <returns>True if any Scenario is loaded on the screen, false if not.</returns>
        public static bool IsAnyScenarioLoaded(this ScreenManager screenManager) => screenManager.Screen3D.GetChildren()
                                                                                                    .OfType<Scenario>()
                                                                                                    .Any();

        /// <summary>
        /// Changes colour of DirectionalLight3D5
        /// </summary>
        /// <param name="screenManager"></param>
        /// <param name="target"></param>
        /// <param name="cycleDuration"></param>
        /// <param name="originalColor"></param>
        public static Tween ChangeLightingColorB(this ScreenManager screenManager, Color target, float cycleDuration, out Color originalColor)
        {
            Tween hue = screenManager.CreateTween();
            DirectionalLight3D light = screenManager.GetChildren().OfType<DirectionalLight3D>().Where(x => x.Name == "DirectionalLight3D5").FirstOrDefault();
            hue.BindNode(light);
            originalColor = light.LightColor;
            hue.TweenProperty(light, "light_color", target, cycleDuration);
            return hue;
        }

        /// <summary>
        /// Chamges colour of DirectionalLightA
        /// </summary>
        /// <param name="screenManager"></param>
        /// <param name="target"></param>
        /// <param name="cycleDuration"></param>
        /// <param name="originalColor"></param>
        public static Tween ChangeLightingColorA(this ScreenManager screenManager, Color target, float cycleDuration, out Color originalColor)
        {
            Tween hue = screenManager.CreateTween();
            DirectionalLight3D light = screenManager.GetChildren().OfType<DirectionalLight3D>().Where(x => x.Name == "DirectionalLight3D").FirstOrDefault();
            hue.BindNode(light);
            originalColor = light.LightColor;
            hue.TweenProperty(light, "light_color", target, cycleDuration);
            return hue;
        }

        public static (Tween, Tween) ChangeLightingColorAll(this ScreenManager screenManager, Color targetA, Color targetB, float cycleDuration, out Color originalColorA, out Color originalColorB)
        {
            Tween hue1 = screenManager.CreateTween();
            DirectionalLight3D light1 = screenManager.GetChildren().OfType<DirectionalLight3D>().Where(x => x.Name == "DirectionalLight3D").FirstOrDefault();
            hue1.BindNode(light1);
            originalColorA = light1.LightColor;

            Tween hue2 = screenManager.CreateTween();
            DirectionalLight3D light2 = screenManager.GetChildren().OfType<DirectionalLight3D>().Where(x => x.Name == "DirectionalLight3D5").FirstOrDefault();
            hue2.BindNode(light2);
            originalColorB = light2.LightColor;

            hue1.TweenProperty(light1, "light_color", targetA, cycleDuration);
            hue1.SetParallel(true);
            hue1.TweenProperty(light1, "light_color", targetB, cycleDuration);

            return (hue1, hue2);
        }
    }

}
