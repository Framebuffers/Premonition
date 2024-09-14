using Godot;
using Premonition.Managers;

namespace Premonition.Scenarios.UI
{
    public partial class StartButton : Button
    {
        private GameDirector Director { get => GetTree().Root.GetNode<GameDirector>("/root/GameDirector"); }
        // private Control StartScreen { get => GetTree().Root.GetNode<Control>("/root/GameDirector/ScreenManager/UserInterface/Start");}

        private void OnStartButtonPressed()
        {
            Director.SceneManager.LoadRandomizedScenePath();
        }

        private void OnQuitButtonPressed()
        {
            Director.Quit();
        }
    }
}
