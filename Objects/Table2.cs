using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class Table2 : Item
    {
        public override string ItemName => "Table";
        public override string Storyline0 { get; set; } = "[Have you ever wondered why tables stand up? They hold stuff in little pillars just so they don't fall into the ground. That's a puzzle.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[Have you ever wondered why tables stand up? They hold stuff in little pillars just so they don't fall into the ground. That's a puzzle.]",
                1 => $"[Some have four legs, and without one they fall. Some have three, and without one they also fail.]",
                2 => $"[It is always something missing that makes the table fail and drop whatever is on there.]",
                3 => $"[You do wonder a thing...]",
                4 => $"[What if the table were you...]",
                5 => $"[...you lost your train of thought.]",
                _ => $"[]",
            };
        }
    }
}