using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premonition.Managers
{
	public sealed partial class LogManager : Node
	{

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{

		}
	}

	public static class LogManagerExtensions
	{
		public static void ToConsole(this string s) => GD.Print($"{DateTime.Now}: {s}\n");
		public static void ToConsoleAsException(this string s) => GD.PrintErr(s);
	}
}
