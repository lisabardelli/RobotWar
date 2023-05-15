using RW.Entities.Spot;

namespace RW.Entities;
public class Arena
{
    public IList<Coordinates> SquaresTaken { get; set; } = new List<Coordinates>();
    public Coordinates BottomCorner { get; set; }
    public Coordinates TopCorner { get; set; } 
    
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
            return new Coordinates( x, x );
        }
        catch (Exception e)
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
}