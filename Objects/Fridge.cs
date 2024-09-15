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
    }
}
