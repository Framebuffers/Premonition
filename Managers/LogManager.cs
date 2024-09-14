using Godot;
using System;

namespace Premonition.Managers
{
    public sealed partial class LogManager : Node
    {
    }

    public static class LogManagerExtensions
    {
        public static void ToConsole(this string s) => GD.Print($"{DateTime.Now}: {s}\n");
        public static void ToConsoleAsException(this string s) => GD.PrintErr(s);
    }
}
