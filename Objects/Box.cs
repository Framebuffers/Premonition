using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Box : Item
    {
        public override string ItemName => "A box with something inside";
        public override string Storyline0 { get; set; } = "[Nothing but meaningless papers.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[You see a bunch of papers inside.]",
                1 => $"[Some of them are pictures of people you can kind of remember. Some, you don't.]",
                2 => $"[Some are folders. They look important.]",
                3 => $"[You see your name on them.]",
                4 => $"[You can't make head or tails of it. But it might talking about you.]",
                5 => $"[It is talking about you.]",
                _ => $"[Not in table.]",
            };
        }

}