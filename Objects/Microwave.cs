using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Microwave : Item
    {
        public override string ItemName => "Microwave";
        public override string Storyline0 { get; set; } = "[mmmmmmmmmmmmmmmmmmmmmmmm]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }
}