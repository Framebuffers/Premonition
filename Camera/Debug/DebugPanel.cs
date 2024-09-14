using Godot;
using System;

namespace Premonition.Camera.Debug
{
    public partial class DebugPanel : PanelContainer
    {
        public VBoxContainer BoxContainer { get => GetNode<VBoxContainer>("MarginContainer/VBoxContainer"); }

        public void AddProperty(String title, String value, int order)
        {
            if (BoxContainer.GetType() == typeof(VBoxContainer))
            {
                Node target = BoxContainer.FindChild(title, true, false);
                if (target == null)
                {
                    Label label = new Label();
                    BoxContainer.AddChild(label);
                    label.Name = title;
                    label.Text = $"{title}: {value}";
                }
                else if (Visible)
                {
                    Label label = (Label)target;
                    label.Text = $"{title}: {value}";
                    BoxContainer.MoveChild(target, order);
                }
            }
        }

        public void RemoveProperties()
        {
            if (BoxContainer.GetType() == typeof(VBoxContainer))
            {
                foreach (var children in BoxContainer.GetChildren())
                {
                    children.Free();
                }
            }
        }
    }
}
