using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class DoubleBed : Item
    {
        public override string ItemName => "Your bed";
        public override string Storyline0 { get; set; } = "[The window behind you makes you feel like someone's going to jump at your face, like a bug or something. It looks like there's some clouds coming. At you don't have any clothing drying outside.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[Here is the bed, where it all happened.]",
                1 => $"[You've seen the back of both black and white days. Or stormy days like today. Hope you see the back of this day as well.]",
                2 => $"[Anyhow, the days are literally in your back. The back of your head, actually.]",
                3 => $"[The window behind you makes you feel like someone's going to jump at your face, like a bug or something. It looks like there's some clouds coming. At you don't have any clothing drying outside.]",
                4 => $"[You've celebrated the day you first laid your back on this bed. But someone is missing...]",
                5 => $"[The optimism in their eyes makes you tear up. That is something you'll never forget until the end.]",
                _ => $"[Not in table.]",
            };
        }
    }
}
