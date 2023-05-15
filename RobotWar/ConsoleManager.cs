using RW.Entities.Spot;

namespace RW;

internal abstract class ConsoleManager 
{
    public static T BuildObject<T>(string promptMessage, Func<string, T> builder) where T : class?
    {
        while (true)
        {
            try
            {
                Console.WriteLine(promptMessage);
                var input = Console.ReadLine();
                var obj = builder(input);
                if (obj == null) continue;
                return obj;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid Input: {e.Message}");
            }
        }
    }
    
    public static void Print(string? promptMessage, Spot spot)
    {
        Console.WriteLine(promptMessage + "ROBOT POSITION: " + $"{spot.Coordinates.X} {spot.Coordinates.Y} {(char)spot.Direction}");
    }
}