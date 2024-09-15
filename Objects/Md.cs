using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Md : Item
    {
        public override string ItemName => "Game Console";
        public override string Storyline0 { get; set; } = "[There is a disk inside. You turn on the console. It is a music disk. Calm memories of a holiday you once had 20 years ago come to mind. Good times. Wonder what are you up to right now?]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }

}