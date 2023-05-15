namespace RW.Entities.Spot;

public class Spot
{
    public Coordinates Coordinates { get; set; } = null!;

    public CardinalPoint Direction { get; set; }

    public Spot()
    {
    }
    public Spot(Coordinates coordinates, CardinalPoint direction)
    {
        Coordinates = coordinates;
        Direction = direction;
    }

    public Spot Move()
    {
        var actions = new Dictionary<CardinalPoint, Action>
        {
            { CardinalPoint.North, () => Coordinates.Y++ },
            { CardinalPoint.East, () => Coordinates.X++ },
            { CardinalPoint.South, () => Coordinates.Y-- },
            { CardinalPoint.West, () => Coordinates.X-- }
        };

        actions[Direction]();

        return this;
    }

    public CardinalPoint RotateLeft()
    {
        var leftTurns = new Dictionary<CardinalPoint, CardinalPoint>
        {
            { CardinalPoint.North, CardinalPoint.West },
            { CardinalPoint.West, CardinalPoint.South },
            { CardinalPoint.South, CardinalPoint.East },
            { CardinalPoint.East, CardinalPoint.North }
        };

        return leftTurns[Direction];
    }
    
    public CardinalPoint RotateRight()
    {
        var rightTurns = new Dictionary<CardinalPoint, CardinalPoint>
        {
            { CardinalPoint.North, CardinalPoint.East },
            { CardinalPoint.East, CardinalPoint.South },
            { CardinalPoint.South, CardinalPoint.West },
            { CardinalPoint.West, CardinalPoint.North }
        };
        
        return rightTurns[Direction];
    }
}