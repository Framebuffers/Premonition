using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Bottle : Item
    {
        public override string ItemName => "A bottle";
        public override string Storyline0 { get; set; } = "[It's empty. It doesn't have a label. It smells funny, though. Just like good times.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[It smells kind of sweet.]",
                1 => $"[It smells kind of acid.]",
                2 => $"[It smells like it shouldn't be here.]",
                3 => $"[It smells like it is been here a long time.]",
                4 => $"[It smells like something you've never experienced before.]",
                5 => $"[It smells like complete confusion.]",
                _ => $"[Not in table.]",
            };
        }
}