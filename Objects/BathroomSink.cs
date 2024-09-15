using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class BathroomSink : Item
    {
        public override string ItemName => "Sink";
        public override string Storyline0 { get; set; } = "[You feel clean. Not that you have any mirror to look at yourself and check.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[Now you're clean, the cleanest you've been.]",
                1 => $"[To seek nothing is bliss.]",
                2 => $"[You remember when the last tears were shed on this place.]",
                3 => $"[You remember the tears shed before on this place.]",
                4 => $"[Do you grasp what it is in your own hands?]",
                5 => $"[Do you like what it is starting to show in front of you?]",
                _ => $"[Not in table.]",
            };
        }
        }
    }
