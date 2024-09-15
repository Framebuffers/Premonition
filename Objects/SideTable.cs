using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class SideTable : Item
    {
        public override string ItemName => "Small table";
        public override string Storyline0 { get; set; } = "[Those drawers are so packed full of documents and things, that you cannot open them. But, if it is there, it is for a reason. Some reason. A very good one, yes.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }

}