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
        //{
        //    switch (progression)
        //    {
        //        case 0:
        //            return $"[]";
        //        case 1:
        //            return $"[]";
        //        case 2:
        //            return $"[]";
        //        case 3:
        //            return $"[]";
        //        case 4:
        //            return $"[]";
        //        case 5:
        //            return $"[]";
        //        default:
        //            return $"[]";
        //    }
        //}

        protected void OnDialogueOpen(Node3D body)
        {
            try
            {
                _director.ScreenManager.DebugPanel.Visible = true;
                EmitSignal(SignalName.QueueForRandomRemoval);
                EmitSignal(SignalName.BroadcastInteraction);
                switch (Route0.RouteStoryCounter)
                {
                    case 0:
                        GetAlternativeDialogue(Route0.RouteStoryCounter);
                        Route.ChangeSkyLighting(Route0.SkyLightingMode.Darker);
                        $"Case0: {Storyline0}".ToConsole();
                        return;
                    case 1:
                        GetAlternativeDialogue(Route0.RouteStoryCounter);
                        Route.ChangeSkyLighting(Route0.SkyLightingMode.Darker);
                        $"Case1: {Storyline1}".ToConsole();
                        break;
                    case 2:
                        GetAlternativeDialogue(Route0.RouteStoryCounter);
                        Route.ChangeSkyLighting(Route0.SkyLightingMode.Darker);
                        $"Case2: {Storyline2}".ToConsole();
                        break;
                    case 3:
                        GetAlternativeDialogue(Route0.RouteStoryCounter);
                        Route.ChangeSkyLighting(Route0.SkyLightingMode.Darker);
                        $"Case3: {Storyline3}".ToConsole();
                        break;
                    case 4:
                        GetAlternativeDialogue(Route0.RouteStoryCounter);
                        Route.ChangeSkyLighting(Route0.SkyLightingMode.Darker);
                        $"Case4: {Storyline4}".ToConsole();
                        break;
                    case 5:
                        GetAlternativeDialogue(Route0.RouteStoryCounter);
                        Route.ChangeSkyLighting(Route0.SkyLightingMode.Darker);
                        $"Case5: {Storyline5}".ToConsole();
                        break;
                    default:
                        GetAlternativeDialogue(Route0.RouteStoryCounter);
                        Route.ChangeSkyLighting(Route0.SkyLightingMode.Lighter);
                        "Case0".ToConsole();
                        break;
                }
            }
            catch (NullReferenceException r)
            {
                AddDialogue(MissingElementLine, 0);
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