using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using System.Text;
using System.Threading.Tasks;

namespace Premonition.Managers
{
	public sealed partial class GameDirector : Node
	{
		// ----------------------------------------------------------------
		// Properties
		public ScreenManager ScreenManager => GetNode<ScreenManager>(ScreenManagerPath);
		public SceneManager SceneManager => GetNode<SceneManager>(SceneManagerPath);
		public LogManager LogManager => GetNode<LogManager>(LogManagerPath);

		// ----------------------------------------------------------------
		// Functions
		public override void _Ready()
		{
			var gv1 = Engine.GetVersionInfo().Values;
			GD.Print($"Obsidian Framework for Godot \n(C) Copyright 2024 Framebuffer. Version 2024.09.\n\tRunning on Godot {gv1.Last()}.\n\tArchitecture: {Engine.GetArchitectureName()}\n\tGame: {this.GetType().AssemblyQualifiedName}\n\tAuthor: Framebuffer\n\tLicense: MIT Licence\n\n");
		}
	}

	public static class GameDirectorExtensions
	{
		public static GameDirector GetGameDirector(this Node n) => n.GetNode<GameDirector>("/root/GameDirector");
	}
}
