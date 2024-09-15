using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Fridge : Item
    {
        public override string ItemName => "Your fridge";
        public override string Storyline0 { get; set; } = "[You don't really feel hungry. And it's cold inside. Don't want to catch a cold with the breeze of the fridge hitting your face.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[You don't really feel hungry. And it's cold inside. Don't want to catch a cold with the breeze of the fridge hitting your face.]",
                1 => $"[The other day you went to fill it up.]",
                2 => $"[You ended up at the hardware store, thinking nails were chips and motor oil was vinegar.]",
                3 => $"[Hope you forget that embarrasment of a mishap. You have written down the directions to the grocery store.]",
                4 => $"[Actually, where are the things you did indeed buy that day?]",
                5 => $"[It is a mystery. That's a puzzle.]",
                _ => $"[Not in table.]",
            };
        }
    }
}
