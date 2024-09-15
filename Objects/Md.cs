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
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[There is a disk inside. You turn on the console. It is a music disk. Calm memories of a holiday you once had 20 years ago come to mind. Good times. Wonder what are you up to right now?]",
                1 => $"[You used to stare at the boot-up screen for hours. Pretty colours and nice music. What a great machine. You didn't even need games to have fun.]",
                2 => $"[You know, there was this place where you could get disks and cartdriges to make this machine do pretty things. But it's not there anymore. At least, not through this fog.]",
                3 => $"[Those days were wild. You even made your own games for it! Here, in the back, on your office.]",
                4 => $"[I don't remember the game for it, but I don't even think if it is for this thing.]",
                5 => $"[The music is frightening.]",
                _ => $"[Not in table.]",
            };
        }

    }
}