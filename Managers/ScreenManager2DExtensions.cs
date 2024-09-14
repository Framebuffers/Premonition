using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Premonition.Managers
{
    public static partial class ScreenManagerExtensions
    {
        // add as path
        public static void AddToScreen2D(this ScreenManager screenManager, string pathToScene, out Node reference)
        {
            Node? node = pathToScene.InstantiatePathAsScene();
            screenManager.Screen2D.AddChild(node);
            reference = node;
        }

        // add as node
        public static void AddToScreen2D(this ScreenManager s, Node n, out Node reference)
        {
            s.Screen2D.AddChild(n);
            reference = n;
        }

        public static void AddToScreen2D<T>(this ScreenManager s, T n, out T reference) where T : Node
        {
            s.Screen2D.AddChild(n);
            reference = n;
        }

        public static void AddToScreen2D<T>(this ScreenManager s, string nodePath, out T reference) where T : Node
        {
            nodePath.InstantiatePathAsScene<T>(out var node);
            s.Screen2D.AddChild(node);
            reference = node;
        }

        // clear all
        public static void ClearScreen2D(this ScreenManager screenManager)
        {
            $"\nClearing all UI elements from screen...".ToConsole();
            foreach (var child in screenManager.Screen2D.GetChildren())
            {
                screenManager.Screen2D.RemoveChild(child);
            }
        }

        // remove specific node
        public static void RemoveFromScreen2D(this ScreenManager screenManager, Node n)
        {
            $"\nRemoving 2D element from screen...".ToConsole();
            screenManager.Screen2D.RemoveChild(n);
        }
        public static List<Node> GetUIElementsOnScreen(this ScreenManager screenManager) => screenManager.UserInterface.GetChildren().ToList();
        public static Node? GetUIElement(this ScreenManager screenManager, Node n)
        {
            return screenManager.GetUIElementsOnScreen().Where(child => child == n).FirstOrDefault() ?? null;
        }
    }



}