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
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[Let your mind do the walking, let my body do flying.]",
                1 => $"[You took you to the highests of mountains, but couldn't take it to the deepest of seas. It's not a place for luggage like this anyways.]",
                2 => $"[I feel like these words came from somewhere.]",
                3 => $"[All the islands in the oceans, and the heavens in Earth, yet you still can't find the place you came from.]",
                4 => $"[The world inside your eyes is getting kind of blurry.]",
                5 => $"[It's misty outside. You'd better not go out.]",
                _ => $"[Not in table]",
            };
        }
}