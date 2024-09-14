using Godot;
using System.Diagnostics;
using System.Linq;

namespace Premonition.Managers
{
    public sealed partial class GameDirector : Node
    {
        // ----------------------------------------------------------------
        // Properties
        public ScreenManager ScreenManager => GetNode<ScreenManager>(ScreenManagerPath);
        public SceneManager SceneManager => GetNode<SceneManager>(SceneManagerPath);
        public LogManager LogManager => GetNode<LogManager>(LogManagerPath);
        private bool EscapeKeyPressed = false;

        public void Quit()
        {
            GetTree().Root.PropagateNotification((int)NotificationWMCloseRequest);
            GetTree().Quit();
        }

        // ----------------------------------------------------------------
        // Functions
        public override void _Ready()
        {
            var gv1 = Engine.GetVersionInfo().Values;
            GD.Print($"Obsidian Framework for Godot \n(C) Copyright 2024 Framebuffer. Version 2024.09.R2.\n\tRunning on Godot {gv1.Last()}.\n\tArchitecture: {Engine.GetArchitectureName()}\n\tGame: {this.GetType().AssemblyQualifiedName}\n\tAuthor: Framebuffer\n\tLicense: MIT Licence\n\n");
        }

        public override void _Input(InputEvent @event)
        {
            if (@event is InputEventKey keyEvent && keyEvent.Pressed)
            {
                if (keyEvent.Keycode == Key.Escape)
                {
                    Stopwatch t = new();
                    t.Start();
                    if (!EscapeKeyPressed)
                    {
                        $"Escape key pressed. Press it again to quit.".ToConsole();
                        EscapeKeyPressed = true;
                        if (t.ElapsedMilliseconds > 3000) EscapeKeyPressed = false;
                        t.Stop();
                    }
                    else
                    {
                        $"Quitting...".ToConsole();
                        Quit();
                    }
                }
            }
        }
    }

    public static class GameDirectorExtensions
    {
        public static GameDirector GetGameDirector(this Node n) => n.GetNode<GameDirector>("/root/GameDirector");
    }

    public sealed partial class GameDirector : Node
    {
        // [Paths]
        // ----------------------------------------------------------------
        // Bootstrap Scene

        // public const string BootstrapScene = "res://Scenarios/Route1.tscn";

        // ----------------------------------------------------------------
        // Managers
        public const string GameDirectorPath = "/root/GameDirector";
        public const string SceneManagerPath = "/root/GameDirector/SceneManager";
        public const string ScreenManagerPath = "/root/GameDirector/ScreenManager";
        public const string LogManagerPath = "/root/GameDirector/LogManager";

        // ----------------------------------------------------------------
        // Viewports
        public const string ScreenContainerPath = "/root/GameDirector/ScreenManager/ScreenContainer";
        public const string Screen2DPath = "/root/GameDirector/ScreenManager/ScreenContainer/Screen2D";
        public const string Screen3DPath = "/root/GameDirector/ScreenManager/ScreenContainer/Screen3D";

        // ----------------------------------------------------------------
        // Players
        public const string PlayersPath = "/root/GameDirector/ScreenManager/ScreenContainer/Screen3D/Players";

        // ----------------------------------------------------------------
        // UI
        public const string UserInterfacePath = "/root/GameDirector/ScreenManager/UserInterface";
        public const string DebugPanelPath = "/root/GameDirector/ScreenManager/UserInterface/DebugPanel";
    }
}
