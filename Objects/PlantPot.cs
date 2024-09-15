using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class PlantPot : Item
    {
        public override string ItemName => "Plant";
        public override string Storyline0 { get; set; } = "[At times, you wish you were a plant. Plants don't have to think, work or worry about human things. Just hang around and get warm sunrays and water. It is something so simple, yet so deep for you.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[At times, you wish you were a plant. Plants don't have to think, work or worry about human things. Just hang around and get warm sunrays and water. It is something so simple, yet so deep for you.]",
                1 => $"[You could also be a radio model.]",
                2 => $"[That way everyone can see you... no, you mean, hear you.]",
                3 => $"[But wait, you cannot see the people on the radio?]",
                4 => $"[I see them every day. They're my friends!]",
                5 => $"[I am never alone as long as this plant gives me company.]",
                _ => $"[Not in table.]",
            };
        }
    }
}