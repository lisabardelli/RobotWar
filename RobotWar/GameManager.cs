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
}