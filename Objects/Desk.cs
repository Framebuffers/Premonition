using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Desk : Item
    {
        public override string ItemName => "Your desk";
        public override string Storyline0 { get; set; } = "[You spent the whole week here churning something to show everyone, but it still needs a bit more time. Those blinkenlights look pretty, though.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }
}

