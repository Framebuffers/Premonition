﻿using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premonition.Managers
{
	/// <summary>
	/// Manager for loading, unloading and manipulation of Scenes inside the game.
	/// </summary>
	public sealed partial class SceneManager : Node
	{
		// Note: Deferred calles are done through a pair of public and private methods. 
		// Deferred methods have the same name as the public methods, with the "Deferred" suffix.
		[Required]
		private GameDirector Director { get => this.GetGameDirector(); }
		/// <summary>
		/// Current main game Scene loaded on Screen3D.
		/// </summary>
		public Node? CurrentScene { get; set; }

		/// <summary>
		/// Current Player holding the Camera.
		/// </summary>
		public CharacterBody3D? CurrentCharacter { get; set; }

		/// <summary>
		/// Reference to the ScreenManager. Any calls to Screens are made through this.
		/// </summary>
		[Required]
		public ScreenManager ScreenManager => Director.ScreenManager;

		public override void _Ready()
		{
			$"Loaded at: {GetPath()}".ToConsole();
		}

		// ****************************************************************
		// Player loading

		public void LoadPlayer(string characterPath)
		{
			CallDeferred(MethodName.LoadPlayerDeferred, characterPath);
		}

		public void LoadPlayer(Node characterNode)
		{
			CallDeferred(MethodName.LoadPlayerNodeDeferred, characterNode);
		}

		private void LoadPlayerDeferred(string characterPath)
		{
			ScreenManager.AddPlayer(characterPath, out CharacterBody3D c);
			CurrentCharacter = c;
		}

		private void LoadPlayerNodeDeferred(Node characterNode)
		{
			ScreenManager.AddPlayer(characterNode, out CharacterBody3D c);
			CurrentCharacter = c;
		}

		// ****************************************************************
		// Scene loading

		public void LoadScene(string path)
		{
			$"Moving to string path: {path}".ToConsole();
			CallDeferred(MethodName.LoadSceneDeferred, path);
		}

		public void AddScene(string path)
		{
			$"Adding scene from string path: {path}".ToConsole();
			CallDeferred(MethodName.LoadSceneDeferred, path);
		}

		public void LoadSubScene(Node node)
		{
			$"Adding scene from {node.Name}".ToConsole();
			CallDeferred(MethodName.LoadSubSceneDeferred, node);
		}

		public void UnloadSubScene(Node node)
		{
			$"Unloading scene {node.Name}...".ToConsole();
			CallDeferred(MethodName.UnloadSubSceneDeferred, node);
		}

		// Deferred = called only when all the code from the current scene has been executed.
		private void LoadSceneDeferred(string path)
		{
			$"Instantiating new scene from string path: {path}.".ToConsole();
			if (Director.ScreenManager.IsAnyScenarioLoaded() && Director.ScreenManager.Screen3D != null) ScreenManager.RemoveCurrentScene(this);
			ScreenManager.AddAsCurrentScene(this, path.InstantiatePathAsScene(), out _);
		}

		private void LoadSubSceneDeferred(Node scene)
		{
			$"Instantiating new scene from Node object: {scene.GetPath()}.".ToConsole();
			if (Director.ScreenManager.IsAnyScenarioLoaded()) ScreenManager.RemoveCurrentScene(this);
			ScreenManager.AddAsCurrentScene(this, scene, out _);
		}


		private void UnloadSubSceneDeferred(Node node)
		{
			$"Unloading child scene {node.Name}...".ToConsole();
			ScreenManager.RemoveFromScreen3D(node);
		}
	}
}