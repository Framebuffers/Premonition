using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class Shower : Item
    {
        public override string ItemName => "Shower";
        public override string Storyline0 { get; set; } = "[With time you wished you could have larger bathrooms to have a bathtub instead of a shower. There should be room in this house, anyways.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[With time you wished you could have larger bathrooms to have a bathtub instead of a shower. There should be room in this house, anyways.]",
                1 => $"[You built this house. You built it on a city sprawling into the horizon. Just like now, you couldn't see the end of it.]",
                2 => $"[It's just a question of time until I get this sorted.]",
                3 => $"[It's cramped, though.]",
                4 => $"[Somebody has to do something...]",
                5 => $"[It's too hard to even open, or get in, or use it. Something has to be done.]",
                _ => $"[Not in table.]",
            };
        }

}