using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class Sofa : Item
    {
        public override string ItemName => "Sofa";
        public override string Storyline0 { get; set; } = "It's been a while since I sat on that couch, but it looks like someone's been here already.";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[It's been a while since I sat on that couch, but it looks like someone's been here already.]",
                1 => $"[It's soft.]",
                2 => $"[It's comfy.]",
                3 => $"[It has your smell. And some others you are familiar with.]",
                4 => $"[It's perfect for two of us.]",
                5 => $"[Let me invite someone over. Should be here around the house.]",
                _ => $"[Not in table.]",
            };
        }

    }
}