using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class KitchenTv : Item
    {
        public override string ItemName => "TV";
        public override string Storyline0 { get; set; } = "[Seems like the weather is getting a bit spicy. You feel a bit uneasy, mainly because storms are loud and scary. But there's a lot of room to hide here.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }
}