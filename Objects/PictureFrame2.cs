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
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[Something did happen here. It's mind-boggling.]",
                1 => $"[It was a home for many.]",
                2 => $"[You felt comfortable there.]",
                3 => $"[People you never met, yet they were like long-lasting friends.]",
                4 => $"[You could be so expressive, creative, free.]",
                5 => $"[It is a good memory from the past. One that will last forever etched like carving into the sand of an endless beach. But you'll always come back and re-write it, verbatim. This is the power of a home.]",
                _ => $"[]",
            };
        }

    }