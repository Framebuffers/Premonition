using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Piano : Item
    {
        public override string ItemName => "Piano";
        public override string Storyline0 { get; set; } = "[You remember something about the Passacaglia, from Stravinsky's Septet. You'd play it wrong, but that would have been okay. Why would you have such a majestic piano if you can't play it, anyways?]";
        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[You remember something about the Passacaglia, from Stravinsky's Septet. You'd play it wrong, but that would have been okay. Why would you have such a majestic piano if you can't play it, anyways?]]",
                1 => $"[You heard that piece on a place, long ago, but not at a concert.]",
                2 => $"[It might've been here, actually.]",
                3 => $"[Maybe on that console over there?]",
                4 => $"[You do remember how to play this piano.]",
                5 => $"[You know exactly how. You never forgot. This is fascinating.]",
                _ => $"[Not in table.]",
            };
        }
}