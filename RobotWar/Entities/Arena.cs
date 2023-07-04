
namespace RW.Entities;
public class Arena
{
    private HashSet<Coordinates> SquaresTaken { get; } = new HashSet<Coordinates>();
    private Coordinates BottomCorner { get; }
    private Coordinates TopCorner { get; }

    public Arena(string topRightCorner)
    {
        BottomCorner = new Coordinates(0, 0);
        TopCorner = ParseCoordinates(topRightCorner);
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
    
    private Coordinates ParseCoordinates(string topCorner)
    {
        var split = topCorner.Split(' ');
        var x = int.Parse(split[0]);
        var y = int.Parse(split[1]);

        return new Coordinates(x, y);
    }
}