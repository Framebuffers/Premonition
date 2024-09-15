using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Microwave : Item
    {
        public override string ItemName => "Microwave";
        public override string Storyline0 { get; set; } = "[mmmmmmmmmmmmmmmmmmmmmmmm]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[mmmmmmmmmmmmmmmmmmmmmmmm]",
                1 => $"[what does this button doooo?]",
                2 => $"[Don't fall into the intrusive thoughts.]",
                3 => $"[Why does it even have that many buttons anyway?]",
                4 => $"[You always pressed the same button to cook meals.]",
                5 => $"[Which one was it?]",
                _ => $"[Not in table.]",
            };
        }
    }
}