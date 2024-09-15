using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class DiningRoomTable : Item
    {
        public override string ItemName => "Dining Table";
        public override string Storyline0 { get; set; } = "[This is a table. You do remember some candid conversations with people, some you wish to not remember. Better to leave the good ones remain.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[This is a table. You do remember some candid conversations with people, some you wish to not remember. Better to leave the good ones remain.]]",
                1 => $"[The best memories were made with friends that have come and went through this very space.]",
                2 => $"[The worst ones bring you a sense of dread.]",
                3 => $"[You do recall one conversation. In fact, it was about you. About your very self.]",
                4 => $"[Do you hear that voice coming from elsewhere? It has to be somewhere.]",
                5 => $"[You hear someone yelling that you are going crazy. It's making you feel helpless.]",
                _ => $"[Not in table.]",
            };

        }
    }
}
