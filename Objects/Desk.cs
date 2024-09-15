using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class Desk : Item
    {
        public override string ItemName => "Your desk";
        public override string Storyline0 { get; set; } = "[You spent the whole week here churning something to show everyone, but it still needs a bit more time. Those blinkenlights look pretty, though.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[These machines were very expensive. Work gave them to me, so I could work remote. So advanced!]",
                1 => $"[You spent the whole week here churning something to show everyone, but it still needs a bit more time. Those blinkenlights look pretty, though.]",
                2 => $"[These computers used to be so easy to understand to you. You even made games with them. Games people loved and rejoiced. Games that made lasting memories.]",
                3 => $"[Do you have lasting memories of those days making games?]",
                4 => $"[You do remember a couple games. Some were made in a week. Rough but meaningful.]",
                5 => $"[Why are they even here, if you have not worked in years?]",
                _ => $"[Not in table.]",
            };
        }
}

