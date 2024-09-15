using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Luggage : Item
    {
        public override string ItemName => "Luggage";
        public override string Storyline0 { get; set; } = "[Remember when you had to call Customer Support because you got someone else's bag, because they were both identical? You are very sure it is your bag. After that embarrassment, you're very sure it is yours.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }
}