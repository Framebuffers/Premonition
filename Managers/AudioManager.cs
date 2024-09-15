using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Radios;
using Windows.Media.Protection.PlayReady;
using WinRT;

namespace Premonition.Managers
{
    public sealed partial class AudioManager : Node
    {
        private GameDirector _director { get => this.GetGameDirector(); }
        public IEnumerable<AudioStreamPlayer> GetAudioStreams() => _director.ScreenManager.Screen3D
            .GetChildren()
            .Where(x => x is AudioStreamPlayer)
            .Cast<AudioStreamPlayer>();
    }

    public static class AudioManagerExtensions
    {
        public static void FadeOutAudio(this AudioStreamPlayer stream, Action onFinishPlayback)
        {
            using Tween t = stream.CreateTween();
            t.TweenProperty(stream, "volume_db", -80.0f, 1.00f)
             .SetTrans(Tween.TransitionType.Sine)
             .SetEase(Tween.EaseType.In);
            if (onFinishPlayback != null) t.Finished += onFinishPlayback;
            else stream.Stop();
        }

        public static void AddAudioPlayback(this AudioManager stream, AudioStreamPlayer audio) => stream.AddChild(audio);

        public static void RemoveAudioPlayback(this AudioManager stream, AudioStreamPlayer nodeToRemove) => nodeToRemove.FadeOutAudio(() => stream.GetChildren().Remove(nodeToRemove));

        public static void LoadAudioFromPath(this AudioManager a, string path, out AudioStreamPlayer instance)
        {
            path.InstantiatePathAsScene<AudioStreamPlayer>(out AudioStreamPlayer i);
            a.AddChild(i);
            instance = i;
        }


    }
}
