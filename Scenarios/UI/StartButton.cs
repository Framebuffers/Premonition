using Godot;
using Premonition.Managers;

namespace Premonition.Scenarios.UI
{
    public partial class StartButton : Button
    {
        private GameDirector Director { get => GetTree().Root.GetNode<GameDirector>("/root/GameDirector"); }
        // private Control StartScreen { get => GetTree().Root.GetNode<Control>("/root/GameDirector/ScreenManager/UserInterface/Start");}
        private AudioStreamPlayer Audio { get => GetTree().Root.GetNode<AudioStreamPlayer>("/root/GameDirector/ScreenManager/ScreenContainer/Screen3D/Intro/AudioStreamPlayer"); }
        private void OnStartButtonPressed()
        {
            Audio.FadeOutAudio(Director.SceneManager.LoadRandomizedScenePath);
            //Tween t = Audio.CreateTween();
            //t.TweenProperty(Audio, "volume_db", -80.0f, 1.00f)
            // .SetTrans(Tween.TransitionType.Sine)
            // .SetEase(Tween.EaseType.In);
            //t.Finished += Director.SceneManager.LoadRandomizedScenePath;
        }

        private void OnQuitButtonPressed()
        {
            Director.Quit();
        }
    }
}
