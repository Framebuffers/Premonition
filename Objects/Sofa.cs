using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class Sofa : Item
    {
        public override string ItemName => "Sofa";
        public override string Storyline0 { get; set; } = "It's been a while since I sat on that couch, but it looks like someone's been here already.";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }

}