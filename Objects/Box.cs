using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Box : Item
    {
        public override string ItemName => "A box with something inside";
        public override string Storyline0 { get; set; } = "[Nothing but meaningless papers.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }

}