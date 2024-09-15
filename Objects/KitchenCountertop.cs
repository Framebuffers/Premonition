using Premonition.Nodes.Abstractions;

namespace Premonition.Objects
{
    public partial class KitchenCountertop : Item
    {
        public override string ItemName => "Kitchen";
        public override string Storyline0 { get; set; } = "[There's a very thin layer of dust on top. You order takeout most of the time, anyways. You can't even cook an egg.]";

        public override string Storyline1 { get; set; } = "[Not in table]";
        public override string Storyline2 { get; set; } = "[Not in table]";
        public override string Storyline3 { get; set; } = "[Not in table]";
        public override string Storyline4 { get; set; } = "[Not in table]";
        public override string Storyline5 { get; set; } = "[Not in table]";
        public override string GetAlternativeDialogue(int progression)
        {

            return progression switch
            {
                0 => $"[There's a very thin layer of dust on top. You order takeout most of the time, anyways. You can't even cook an egg.]",
                1 => $"[But why can't you cook an egg?]",
                2 => $"[Eggs are round, soft things to take care of. They have little chicks inside that have to grow up with tender love and care!]",
                3 => $"[I took care of one the other day, but I tripped on it and it broke. It hurt.]",
                4 => $"[Don't know if it hurt more the fall or losing my poor egg, Tem.]",
                5 => $"[You are vegan, anyways.]",
                _ => $"[Not in table.]",
            };
        }

}