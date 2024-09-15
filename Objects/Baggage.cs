using Godot;
using Premonition.Nodes.Abstractions;
using System;

public partial class Baggage : Item
{
    public override string ItemName => "Luggage";
    public override string Storyline0 { get; set; } = "[Didn't it get lost 20 years ago? It's empty, anyways. You might've already unpacked or something.]";
    public override string Storyline1 { get; set; } = "[Not in table]";
    public override string Storyline2 { get; set; } = "[Not in table]";
    public override string Storyline3 { get; set; } = "[Not in table]";
    public override string Storyline4 { get; set; } = "[Not in table]";
    public override string Storyline5 { get; set; } = "[Not in table]";
}
