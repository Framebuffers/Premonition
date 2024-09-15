using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Cake : Item
    {
        public override string ItemName => "Birthday Cake";
        public override string Storyline0 { get; set; } = "[Someone special is coming! Better get the house sorted up for the guests! You wonder who's gonna come...]";
        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[It's someone's birthday! You can feel the excitement.]",
                1 => $"[Do you remember who is this cake for?]",
                2 => $"[Oh, was it for the girl you never saw again?]",
                3 => $"[Though it's not here, it means something.]",
                4 => $"[You were a kid. And you cried a lot.]",
                5 => $"[You have some bad memories about birthday cakes. You hope she comes back someday.]",
                _ => $"[Not in table.]",
            };


        }

}
