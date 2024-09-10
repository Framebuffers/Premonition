using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premonition.Managers
{
	public sealed partial class GameDirector : Node
	{
		// [Paths]
		// ----------------------------------------------------------------
		// Bootstrap Scene
		public const string BootstrapScene = "res://Scenarios/Debug/TestRooms/Room03/S00003.tscn";

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
	}
}
