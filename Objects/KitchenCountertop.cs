using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class KitchenCountertop : Item
    {
        public override string ItemName => "Kitchen";
        public override string Storyline0 { get; set; } = "[There's a very thin layer of dust on top. You order takeout most of the time, anyways. You can't even cook an egg.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }

}