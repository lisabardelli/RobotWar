
namespace RW.Entities;
public class Arena
{
    private HashSet<Coordinates> SquaresTaken { get; } = new HashSet<Coordinates>();
    public Coordinates BottomCorner { get; }
    public Coordinates TopCorner { get; }

    public Arena(string topRightCorner)
    {
        BottomCorner = new Coordinates(0, 0);
        TopCorner = CreateArenaCoordinates(topRightCorner);
    }

    private static Coordinates CreateArenaCoordinates(string topRightCorner)
    {
        try
        {
            var x = int.Parse(topRightCorner);
            return new Coordinates(x, x);
        }
        catch (Exception)
        {
            throw new Exception("Input must be a number");
        }
    }

    public bool IsSpotAlreadyTaken(Coordinates coordinates)
    {
        return SquaresTaken.Any(spot => spot.X == coordinates.X && spot.Y == coordinates.Y);
    }

    public bool IsSpotInsideArena(Coordinates coordinates)
    {
        return coordinates.X >= BottomCorner.X && coordinates.X <= TopCorner.X &&
               coordinates.Y >= BottomCorner.X && coordinates.Y <= TopCorner.Y;
    }

    public void TakeSpot(Coordinates coordinates)
    {
        if (IsSpotAlreadyTaken(coordinates))
        {
            throw new Exception("Spot is already taken");
        }

        if (!IsSpotInsideArena(coordinates))
        {
            throw new Exception("Spot is outside the arena");
        }

        SquaresTaken.Add(coordinates);
    }

    public void RemoveSquare(Coordinates coordinates)
    {
        if (!IsSpotAlreadyTaken(coordinates))
        {
            throw new Exception("Already removed");
        }

        if (!IsSpotInsideArena(coordinates))
        {
            throw new Exception("Spot is outside the arena");
        }

        SquaresTaken.Remove(coordinates);
    }
}