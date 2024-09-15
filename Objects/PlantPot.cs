using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class PlantPot : Item
    {
        public override string ItemName => "Plant";
        public override string Storyline0 { get; set; } = "[At times, you wish you were a plant. Plants don't have to think, work or worry about human things. Just hang around and get warm sunrays and water. It is something so simple, yet so deep for you.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }

}