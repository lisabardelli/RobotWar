namespace RW.Entities;

public class Spot
{
    public Coordinates Coordinates { get; set; } = null!;

    public CardinalPoint Direction { get; set; }

    public Spot(Spot previousSpot)
    {
        Coordinates = new Coordinates(previousSpot.Coordinates);
        Direction = previousSpot.Direction;
    }
    public Spot(Coordinates coordinates, CardinalPoint direction)
    {
        Coordinates = coordinates;
        Direction = direction;
    }

    public Spot()
    {
    }
}