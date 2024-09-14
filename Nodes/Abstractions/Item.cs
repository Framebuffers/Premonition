using Godot;
using Premonition.Camera.Debug;
using Premonition.Managers;

namespace Premonition.Nodes.Abstractions
{
    public abstract partial class Item : StaticBody3D
    {
        [Signal]
        public delegate void InteractionEventHandler();

        [Signal]
        public delegate void ObjectHidingEventHandler();

        public virtual string ItemName { get; } = "[Not in table]";
        private GameDirector _director { get => this.GetGameDirector(); }
        private uint CurrentStoryline { get => _director.SceneManager.CurrentStoryline; }
        private DebugPanel DialoguePanel { get => _director.ScreenManager.DebugPanel; }
        private void RemoveDialogue()
        {
            _director.ScreenManager.DebugPanel.Visible = false;
            DialoguePanel.RemoveProperties();
        }

        public string GetDialogueFromStoryline(int storyline)
        {
            return storyline switch
            {
                0 => Storyline0,
                1 => Storyline1,
                2 => Storyline2,
                3 => Storyline3,
                4 => Storyline4,
                _ => Storyline5,// Not in table.
            };
        }

        public string SetDialogueFromStoryline(int storyline, string text)
        {
            return storyline switch
            {
                0 => Storyline0 = text,
                1 => Storyline1 = text,
                2 => Storyline2 = text,
                3 => Storyline3 = text,
                4 => Storyline4 = text,
                _ => Storyline5,// Not in table.
            };
        }

        private void AddDialogue(string body, int order) => DialoguePanel.AddProperty(ItemName, body, order);

        private const string DefaultAnswer = "Oh yeah! I'm pretty sure this is [Not in table].";
        public abstract string Storyline0 { get; set; }
        public abstract string Storyline1 { get; set; }
        public abstract string Storyline2 { get; set; }
        public abstract string Storyline3 { get; set; }
        public abstract string Storyline4 { get; set; }
        public abstract string Storyline5 { get; set; }
        protected void OnDialogueOpen(Node3D body)
        {
            _director.ScreenManager.DebugPanel.Visible = true;
            EmitSignal(SignalName.ObjectHiding);
            switch (CurrentStoryline)
            {
                case 0:
                    AddDialogue(Storyline0, 0);
                    $"Case0: {Storyline5}".ToConsole();
                    break;
                case 1:
                    AddDialogue(Storyline1, 0);
                    $"Case1: {Storyline5}".ToConsole();
                    break;
                case 2:
                    AddDialogue(Storyline2, 0);
                    $"Case2: {Storyline5}".ToConsole();
                    break;
                case 3:
                    AddDialogue(Storyline3, 0);
                    $"Case3: {Storyline5}".ToConsole();
                    break;
                case 4:
                    AddDialogue(Storyline4, 0);
                    $"Case4: {Storyline5}".ToConsole();
                    break;
                case 5:
                    AddDialogue(Storyline5, 0);
                    $"Case5: {Storyline5}".ToConsole();
                    break;
                default:
                    AddDialogue(DefaultAnswer, 0);
                    "Case0".ToConsole();
                    break;
            }
        }

        protected void OnDialogueClose(Node3D body)
        {
            //_ = body; // signature has to match to be able to connect signal back to Godot, this is to throw away the unused Body parameter.	
            RemoveDialogue();
        }

        private void HideObject() => this.Visible = false;

        public override void _Ready()
        {
            base._Ready();
            

        }
    }
}