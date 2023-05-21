namespace RW;

public class ConsoleManager
{
    public static string ReadUserInput(string promptMessage)
    {
        Console.WriteLine(promptMessage);
        var input = Console.ReadLine();
        return input;
    }

    public static void Print(string promptMessage)
    {
        Console.WriteLine(promptMessage);
    }
}