using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class SideTable : Item
    {
        public override string ItemName => "Small table";
        public override string Storyline0 { get; set; } = "[Those drawers are so packed full of documents and things, that you cannot open them. But, if it is there, it is for a reason. Some reason. A very good one, yes.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[Those drawers are so packed full of documents and things, that you cannot open them. But, if it is there, it is for a reason. Some reason. A very good one, yes.]",
                1 => $"[You opened it anyways.]",
                2 => $"[Hey, it's you! On a plastic little card. And then some funny cards of various colours and weird numbers.]",
                3 => $"[You do remember: the first digit meant where it came from, the other 2 where it paid to, and the first 6 were the identity of that plastic thingie.]",
                4 => $"[How do you even remember this if you don't even know what day it is?]",
                5 => $"[Sometimes, it's just a question of skill.]",
                _ => $"[Not in table.]",
            };
        }
    }
}