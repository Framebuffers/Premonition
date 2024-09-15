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
    }
}
