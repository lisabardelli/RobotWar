namespace RW.Entities;

public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Coordinates(Coordinates coordinates)
    {
        X = coordinates.X;
        Y = coordinates.Y;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (!(obj is Coordinates))
        {
            return false;
        }

        return X == ((Coordinates)obj).X && (Y == ((Coordinates)obj).Y);
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }
}