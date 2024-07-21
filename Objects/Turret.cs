using System;

class Turret : Object
{
    public override string Type { get; } = "turret";
    public override int Cost { get; } = 5;
    public override int PlayerNumber { get; }

    private Point _direction;

    public Turret(int playerNumber, Point direction)
    {
        if (playerNumber < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        PlayerNumber = playerNumber;

        if (direction.GetDistSquared(new Point(0, 0)) > 1)
        {
            throw new ArgumentOutOfRangeException();
        }
        _direction = direction;
    }

    public override bool IsDealtDamage(Point coord)
    {
        int dist1 = coord.GetDistSquared(new Point(0, 0));
        int dist2 = coord.GetDistSquared(_direction);
        return (dist1 == 2 && dist2 == 1) || dist2 == 0;
    }
}
