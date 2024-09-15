using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class DiningRoomTable : Item
    {
        public override string ItemName => "Dining Table";
        public override string Storyline0 { get; set; } = "[This is a table. You do remember some candid conversations with people, some you wish to not remember. Better to leave the good ones remain.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";

    }
}
