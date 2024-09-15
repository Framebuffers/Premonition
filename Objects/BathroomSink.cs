using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class BathroomSink : Item
    {
        public override string ItemName => "Sink";
        public override string Storyline0 { get; set; } = "[You feel clean. Not that you have any mirror to look at yourself and check.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";

    }
}
