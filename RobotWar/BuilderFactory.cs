namespace RW;

internal abstract class BuilderFactory
{
    public static T BuildObject<T>(string promptMessage, Func<string, T> builder) where T : class?
    {
        while (true)
        {
            try
            {
                var input = ConsoleManager.ReadUserInput(promptMessage);
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
}