using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class Shower : Item
    {
        public override string ItemName => "Shower";
        public override string Storyline0 { get; set; } = "[With time you wished you could have larger bathrooms to have a bathtub instead of a shower. There should be room in this house, anyways.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }

}