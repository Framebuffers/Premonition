using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class Toilet : Item
    {
        public override string ItemName => "Toilet";
        public override string Storyline0 { get; set; } = "[Not today. That sounds worrying, though.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[Not today. That sounds worrying, though.]",
                1 => $"[Actually, real talk. That sounds bad.]",
                2 => $"[You should talk with someone about it.]",
                3 => $"[But who to?]",
                4 => $"[Maybe the doctor that comes every week.]",
                5 => $"[I have to remember to talk about my doctor about this. It might be something very serious.]",
                _ => $"[Not in table.]",
            };
        }

    }
}