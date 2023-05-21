namespace RW.Entities;

public static class CardinalPointExtensions
{
    public static CardinalPoint FromShortString(string directionString)
    {
        return directionString.ToUpper() switch
        {
            "N" => CardinalPoint.North,
            "E" => CardinalPoint.East,
            "S" => CardinalPoint.South,
            "W" => CardinalPoint.West,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}