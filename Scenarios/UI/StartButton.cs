using Godot;
using Premonition.Managers;

public partial class StartButton : Button
{
    private GameDirector _director { get => GetTree().Root.GetNode<GameDirector>("/root/GameDirector"); }
    // private Control StartScreen { get => GetTree().Root.GetNode<Control>("/root/GameDirector/ScreenManager/UserInterface/Start");}
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    private void OnStartButtonPressed()
    {
        _director.SceneManager.LoadRandomizedScenePath();
    }

    private void OnQuitButtonPressed()
    {
        _director.Quit();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
