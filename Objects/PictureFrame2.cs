using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class PictureFrame2 : Item
    {
        public override string ItemName => "A good memory from the past";
        public override string Storyline0 { get; set; } = "[Something did happen here. It's mind-boggling.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
    }

}