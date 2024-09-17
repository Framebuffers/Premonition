using Godot;
using Premonition.Camera.Debug;
using Premonition.Managers;
using Premonition.Scenarios.Routes;
using System;

namespace Premonition.Nodes.Abstractions
{
    public abstract partial class Item : StaticBody3D
    {
        [Signal]
        public delegate void QueueForRandomRemovalEventHandler();

        [Signal]
        public delegate void BroadcastInteractionEventHandler();

        [Signal]
        public delegate void ItemRemovedEventHandler();

        public virtual string ItemName { get; } = "[Not in table]";
        private GameDirector _director { get => this.GetGameDirector(); }
        private uint CurrentStoryline { get => _director.SceneManager.CurrentStoryline; }
        private Route0 Route { get => GetNode<Route0>($"{GameDirector.Screen3DPath}/Route0"); }
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
        public string MissingElementLine { get; set; } = "I swear there was something here... Where could that be?";

        public abstract string GetAlternativeDialogue(int progression);
        protected void OnDialogueOpen(Node3D body)
        {
            try
            {
                _director.ScreenManager.DebugPanel.Visible = true;
                
                switch (Route0.RouteStoryCounter)
                {
                    case 0:
                        AddDialogue(GetAlternativeDialogue(0), 0);
                        Route.ListenToObjectRemoval();
                        $"Case0: {GetAlternativeDialogue(0)}".ToConsole();
                        //EmitSignal(SignalName.QueueForRandomRemoval);
                        //EmitSignal(SignalName.BroadcastInteraction);
                        return;
                    case 1:
                        AddDialogue(GetAlternativeDialogue(1), 0);
                        Route.ListenToObjectRemoval();
                        $"Case1: {GetAlternativeDialogue(1)}".ToConsole();
                        //EmitSignal(SignalName.QueueForRandomRemoval);
                        //EmitSignal(SignalName.BroadcastInteraction);
                        break;
                    case 2:
                        AddDialogue(GetAlternativeDialogue(2), 0);
                        Route.ListenToObjectRemoval();
                        $"Case2: {GetAlternativeDialogue(2)}".ToConsole();
                        //EmitSignal(SignalName.QueueForRandomRemoval);
                        //EmitSignal(SignalName.BroadcastInteraction);
                        break;
                    case 3:
                        AddDialogue(GetAlternativeDialogue(3), 0);
                        Route.ListenToObjectRemoval();
                        $"Case3: {GetAlternativeDialogue(3)}".ToConsole();
                        //EmitSignal(SignalName.QueueForRandomRemoval);
                        //EmitSignal(SignalName.BroadcastInteraction);
                        break;
                    case 4:
                        AddDialogue(GetAlternativeDialogue(4), 0);
                        Route.ListenToObjectRemoval();
                        $"Case4: {GetAlternativeDialogue(4)}".ToConsole();
                        //EmitSignal(SignalName.QueueForRandomRemoval);
                        //EmitSignal(SignalName.BroadcastInteraction);
                        break;
                    case 5:
                        AddDialogue(GetAlternativeDialogue(5), 0);
                        Route.ListenToObjectRemoval();
                        $"Case5: {GetAlternativeDialogue(5)}".ToConsole();
                        //EmitSignal(SignalName.QueueForRandomRemoval);
                        //EmitSignal(SignalName.BroadcastInteraction);
                        break;
                    default:
                        GetAlternativeDialogue(Route0.RouteStoryCounter);
                        "Case0".ToConsole();
                        //EmitSignal(SignalName.QueueForRandomRemoval);
                        //EmitSignal(SignalName.BroadcastInteraction);
                        break;
                }
            }
            catch (NullReferenceException r)
            {
                AddDialogue(MissingElementLine, 0);
                Route.ChangeSkyLighting(Route0.SkyLightingMode.Darker);
                EmitSignal(SignalName.QueueForRandomRemoval);
                EmitSignal(SignalName.BroadcastInteraction);
                _ = r; // this is expected.
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