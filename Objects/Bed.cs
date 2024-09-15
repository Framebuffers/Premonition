using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Bed : Item
    {
        public override string ItemName => "A small bed";
        public override string Storyline0 { get; set; } = "[Seems really tidy for someone to have used it recently. It would be wise to check later if it remains so.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[It's rather small.]",
                1 => $"[Some tender moments happened under this roof. Sweet memories of a family once living here.]",
                2 => $"[It feels kind of moist, did you even close the window?]",
                3 => $"[It might've been the mist.]",
                4 => $"[You wonder if the person that slept here is over there, beyond the mist.]",
                5 => $"[Looking at this bed, you feel alone. Missing someone that you once cared for, in this bed.]",
                _ => $"[Not in table]",
            };
        }
}
