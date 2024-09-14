using Godot;

public partial class Continue : Button
{
    private void OnStartButtonPressed()
    {

    }

    private void OnQuitButtonPressed()
    {
        GetTree().Root.PropagateNotification((int)NotificationWMCloseRequest);
        GetTree().Quit();
    }
}
