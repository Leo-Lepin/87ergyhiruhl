using System;
class Chip : Object
{
    public override string Type { get; } = "chip";
    public override int Cost { get; } = int.MaxValue;
    public override int PlayerNumber { get; }

    public Chip(int playerNumber)
    {
        if (playerNumber < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        PlayerNumber = playerNumber;
    }

    public override bool IsDealtDamage(Point coord)
    {
        return false;
    }
}
