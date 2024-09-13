using Godot;
using Premonition.Camera.Debug;
using Premonition.Managers;
using System;

namespace Premonition.Nodes.Abstractions
{
    public abstract partial class Item : StaticBody3D
    {
        public abstract string Name { get; }
        private GameDirector _director { get => this.GetGameDirector(); }
        private uint CurrentStoryline { get => _director.SceneManager.CurrentStoryline; }
        private DebugPanel DialoguePanel { get => _director.ScreenManager.DebugPanel; }
        private void RemoveDialogue() => DialoguePanel.RemoveProperties();
        private void AddDialogue(string body, int order) => DialoguePanel.AddProperty(Name, body, order);
        private const string DefaultAnswer = "Oh yeah! I'm pretty sure this is [Not in table].";
        public virtual string Storyline0 { get; } = "[Not in table]";
        public virtual string Storyline1 { get; } = "[Not in table]";
        public virtual string Storyline2 { get; } = "[Not in table]";
        public virtual string Storyline3 { get; } = "[Not in table]";
        public virtual string Storyline4 { get; } = "[Not in table]";
        public virtual string Storyline5 { get; } = "[Not in table]";
        private void OnInteraction(Node3D body)
        {
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

        private void OnDialogueClose(Node3D body)
        {
            RemoveDialogue();
        }
    }
}