
namespace RW.Entities;

public class Robot : IRobot
{
    public Spot Spot { get; private set; }
    private Arena InitializedArena { get; }
    private readonly LinkedList<CardinalPoint> _leftTurns;
    private readonly LinkedList<CardinalPoint> _rightTurns;
    private static Dictionary<CardinalPoint, Action<Coordinates>> _moveActions;


    public Robot(ref Arena arena, Spot spot)
    {
        InitializedArena = arena;
        Spot = spot;

        InitializedArena.TakeSpot(Spot.Coordinates);

        _leftTurns = new LinkedList<CardinalPoint>(new[]
        {
            CardinalPoint.West,
            CardinalPoint.South,
            CardinalPoint.East,
            CardinalPoint.North
        });

        _rightTurns = new LinkedList<CardinalPoint>(new[]
        {
            CardinalPoint.East,
            CardinalPoint.South,
            CardinalPoint.West,
            CardinalPoint.North
        });

        _moveActions = new Dictionary<CardinalPoint, Action<Coordinates>>
        {
            { CardinalPoint.North, (coords) => coords.Y++ },
            { CardinalPoint.East, (coords) => coords.X++ },
            { CardinalPoint.South, (coords) => coords.Y-- },
            { CardinalPoint.West, (coords) => coords.X-- }
        };
    }


    public void ChangeSpot(Instruction instruction)
    {
        foreach (var navigationInput in instruction.NavigationInput)
        {
            var input = char.ToUpper(navigationInput);
            switch (input)
            {
                case 'M':
                    if (TryMove())
                    {
                        MarkSpotAsTaken();
                    }
                    else
                    {
                        return;
                    }
                    break;
                case 'L':
                    Spot.Direction = RotateLeft();
                    break;
                case 'R':
                    Spot.Direction = RotateRight();
                    break;
            }
        }

        ConsoleManager.Print("ROBOT POSITION: " + $"{Spot.Coordinates.X} {Spot.Coordinates.Y} {(char)Spot.Direction}");
    }

    private bool TryMove()
    {
        var finalSpot = CalculateFinalSpot();

        if (!IsValidMove(finalSpot)) return false;
        var initialCoordinates = new Coordinates(Spot.Coordinates);
        Spot = finalSpot;
        InitializedArena.RemoveSquare(initialCoordinates);
        return true;
    }

    private bool IsValidMove(Spot spot)
    {
        if (!InitializedArena.IsSpotInsideArena(spot.Coordinates))
        {
            ConsoleManager.Print("Robot cannot move further because it will move outside the arena. \n" +
                                 "ROBOT POSITION: " + $"{Spot.Coordinates.X} {Spot.Coordinates.Y} {(char)Spot.Direction}");
            return false;
        }

        if (InitializedArena.IsSpotAlreadyTaken(spot.Coordinates))
        { 
            ConsoleManager.Print("Robot cannot move further because the next spot is taken. \n" +
                                 "ROBOT POSITION: " + $"{Spot.Coordinates.X} {Spot.Coordinates.Y} {(char)Spot.Direction}");
            return false;
        }
       
        return true;

    }

    private Spot CalculateFinalSpot()
    {
        var tmpSpot = new Spot(Spot);
        _moveActions[Spot.Direction](tmpSpot.Coordinates);
        return tmpSpot;
    }

    private CardinalPoint RotateLeft()
    {
        var current = _leftTurns.Find(Spot.Direction);
        return current?.Next?.Value ?? _leftTurns.First.Value;
    }

    private CardinalPoint RotateRight()
    {
        var current = _rightTurns.Find(Spot.Direction);
        return current?.Next?.Value ?? _rightTurns.First.Value;
    }

    private void MarkSpotAsTaken()
    {
        InitializedArena.TakeSpot(Spot.Coordinates);
    }
}
