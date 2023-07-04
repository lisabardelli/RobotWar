using RW.Builders.Interfaces;
using RW.Entities;

namespace RW;

public class GameManager
{
    private readonly IArenaBuilder _arenaBuilder;
    private readonly IRobotBuilder _robotBuilder;
    private readonly IInstructionBuilder _instructionBuilder;

    public GameManager(IArenaBuilder arenaBuilder, IRobotBuilder robotBuilder, IInstructionBuilder instructionBuilder)
    {
        _arenaBuilder = arenaBuilder;
        _robotBuilder = robotBuilder;
        _instructionBuilder = instructionBuilder;
    }

    internal Arena CreateArena()
    {
        while (true)
        {
            try
            {
                var arenaInput = ConsoleManager.ReadUserInput("Enter top right corner of the arena");
                var arena = _arenaBuilder.BuildArena(arenaInput);
                if (arena == null) continue;
                return arena;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid Input: {e.Message}");
            }
        }
    }
    
    internal Robot CreateRobot(Arena arena)
    {
        while (true)
        {
            try
            {
                var robotInput = ConsoleManager.ReadUserInput("Enter X, Y and direction for the Robot");
                var robot = _robotBuilder.BuildRobot(arena, robotInput);
                if (robot == null) continue;
                return robot;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid Input: {e.Message}");
            }
        }
    }

    internal Instruction CreateInstruction()
    { 
        while (true)
        {
            try
            {
                var navigationInput = ConsoleManager.ReadUserInput("Enter navigation instruction for robot");
                var instruction = _instructionBuilder.BuildInstruction(navigationInput);
                if (instruction == null) continue;
                return instruction;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid Input: {e.Message}");
            }
        }
    }

    /*public void Run()
    {
        var arena = BuilderFactory.BuildObject("Enter top right corner of the arena",
            input => _arenaBuilder.BuildArena(input));
        var robot1 = BuilderFactory.BuildObject("Enter X, Y and direction for the Robot 1",
            input => _robotBuilder.BuildRobot(arena, input));
        var instruction1 = BuilderFactory.BuildObject("Enter navigation instruction for Robot 1",
            input => _instructionBuilder.BuildInstruction(input));

        robot1.ChangeSpot(instruction1);

        var robot2 = BuilderFactory.BuildObject("Enter X, Y and direction for the Robot 2",
            input => _robotBuilder.BuildRobot(arena, input));
        var instruction2 = BuilderFactory.BuildObject("Enter navigation instruction for Robot 2",
            input => _instructionBuilder.BuildInstruction(input));

        robot2.ChangeSpot(instruction2);

    }
    
}*/

/*public class BuilderFactory
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
    }*/
}