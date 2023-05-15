using RW.Builders.Interfaces;
using RW.Entities;

namespace RW.Builders;

public class GameBuilder
{
    private readonly IArenaBuilder _arenaBuilder;
    private readonly IRobotBuilder _robotBuilder;
    private readonly IInstructionBuilder _instructionBuilder;

    public GameBuilder(IArenaBuilder arenaBuilder, IRobotBuilder robotBuilder, IInstructionBuilder instructionBuilder)
    {
        _arenaBuilder = arenaBuilder;
        _robotBuilder = robotBuilder;
        _instructionBuilder = instructionBuilder;
    }

    public void Run()
    {
        Arena arena = ConsoleManager.BuildObject("Enter top right corner of the arena", input => _arenaBuilder.BuildArena(input));
        IRobot robot1 = ConsoleManager.BuildObject("Enter X, Y and direction for the Robot 1", input => _robotBuilder.BuildRobot(arena, input));
        Instruction instruction1 = ConsoleManager.BuildObject("Enter navigation instruction for robot 1", input => _instructionBuilder.BuildInstruction(input));

        robot1.ChangeSpot(instruction1, robot1.Spot, arena);

        IRobot robot2 = ConsoleManager.BuildObject("Enter X, Y and direction for the Robot 2", input => _robotBuilder.BuildRobot(arena, input));
        Instruction instruction2 = ConsoleManager.BuildObject("Enter navigation instruction for robot 2", input => _instructionBuilder.BuildInstruction(input));

        robot2.ChangeSpot(instruction2, robot2.Spot, arena);
    }
}