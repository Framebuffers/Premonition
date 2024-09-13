using Godot;
using Premonition.Camera.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premonition.Managers
{
	/// <summary>
	/// Singleton class managing the scenes being displayed on screen.
	/// Scenes are loaded through the SceneManager to the ScreenManager to one of two SubViewports:
	///     Screen2D: Handles any 2D scene, like the HUD or menus.
	///     Screen3D: Handles any 3D scene, usually the game itself.
	/// 
	/// This node will be the first one being loaded on the screen. 
	/// Any global effects, environments and visual effects are applied here.
	/// Any other functionality, besides containing nodes, are not implemented here.
	/// 
	/// Classes inheriting from TwoTribes.Scenes.Abstractions.Scenario upon receiving a TransitionEventHandler signal
	/// will be unloaded and loaded to this manager.
	/// </summary>
	public sealed partial class ScreenManager : Node
	{
		private GameDirector Director { get => this.GetGameDirector(); }
		public SubViewport Screen2D => GetNode<SubViewport>(GameDirector.Screen2DPath);
		public SubViewport Screen3D => GetNode<SubViewport>(GameDirector.Screen3DPath);
		public Node3D PlayersOnScreen => GetNode<Node3D>(GameDirector.PlayersPath);
		public SubViewportContainer SubViewportContainer => GetNode<SubViewportContainer>(GameDirector.ScreenContainerPath);
		public Control UserInterface => GetNode<Control>(GameDirector.UserInterfacePath);
		public DebugPanel DebugPanel => GetNode<DebugPanel>(GameDirector.DebugPanelPath);
		public Window MainWindow => GetWindow();

		public override void _Ready()
		{
			GetTree().Root.ContentScaleMode = Window.ContentScaleModeEnum.CanvasItems;
			GetTree().Root.ContentScaleStretch = Window.ContentScaleStretchEnum.Integer;
			GetTree().Root.GetViewport().Scaling3DScale = 1.0f;
			SubViewportContainer.Size = new Vector2(GetTree().Root.GetWindow().Size.X, GetTree().Root.GetWindow().Size.Y);
			SubViewportContainer.Stretch = false;
			SetViewportSizes();
			Director.SceneManager.LoadRandomizedScenePath();
		}

		private void SetViewportSizes()
		{
			if (Screen2D != null && Screen3D != null)
			{
				Vector2I size = new((int)SubViewportContainer.GetViewportRect().Size.X, 
									(int)SubViewportContainer.GetViewportRect().Size.Y);
				Screen2D.Size = size;
				Screen3D.Size = size;
			}
			$"Screen2D = {Screen2D.Size.X} x {Screen2D.Size.Y}".ToConsole();
			$"Screen3D = {Screen3D.Size.X} x {Screen3D.Size.Y}".ToConsole();
		}

#pragma warning disable CA1822 // Mark members as static
		private void OnNewPlayerLoaded(Node node) => $"Player loaded from {node.GetPath()}".ToConsole();
		private void OnSceneLoaded(Node node) => $"Scene loaded at {node.GetParent().GetPath()}".ToConsole();
	}
#pragma warning restore CA1822 // Mark members as static
}
