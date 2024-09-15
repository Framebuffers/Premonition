using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{

    public partial class Tv : Item
    {
        public override string ItemName => "TV Set";
        public override string Storyline0 { get; set; } = "[There's something cozy about it. Is it the fuzzyness? The great speakers? It's like a longtime friend, always making you feel good.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[There's something cozy about it. Is it the fuzzyness? The great speakers? It's like a longtime friend, always making you feel good.]",
                1 => $"[Shoot! You forgot to put the VCR on to record that funny show... what was it about? You never knew exactly what was about. Maybe it's just about nothing.]",
                2 => $"[You don't need to have the TV on most of the time. You can hear the talking heads inside your own head. They're annoying.]",
                3 => $"[Like moth to a flame.]",
                4 => $"[I don't like this guy. Makes me feel uneasy.]",
                5 => $"[I don't like to turn off the telly because there's a monster inside. If I turn it off it appears, and it scares me. I am scared. Is it me? Who is it?]",
                _ => $"[Not in table.]",
            };
        }

}