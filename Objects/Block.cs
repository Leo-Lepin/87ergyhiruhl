using System;
class Block : Object
{
    public override string Type { get; } = "block";
    public override int Cost { get; } = 3;
    public override int PlayerNumber { get; }

    public Block(int playerNumber)
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
