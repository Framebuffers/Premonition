using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class Tv : Item
    {
        public override string ItemName => "TV Set";
        public override string Storyline0 { get; set; } = "[There's something cozy about it. Is it the fuzzyness? The great speakers? It's like a longtime friend, always making you feel good.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }

}