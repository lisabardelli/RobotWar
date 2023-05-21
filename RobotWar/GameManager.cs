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

    public void Run()
    {
        var arena = BuilderFactory.BuildObject("Enter top right corner of the arena",
            input => _arenaBuilder.BuildArena(input));
        IRobot robot1 = BuilderFactory.BuildObject("Enter X, Y and direction for the Robot 1",
            input => _robotBuilder.BuildRobot(arena, input));
        var instruction1 = BuilderFactory.BuildObject("Enter navigation instruction for robot 1",
            input => _instructionBuilder.BuildInstruction(input));

        robot1.ChangeSpot(instruction1);

        IRobot robot2 = BuilderFactory.BuildObject("Enter X, Y and direction for the Robot 2",
            input => _robotBuilder.BuildRobot(arena, input));
        var instruction2 = BuilderFactory.BuildObject("Enter navigation instruction for robot 2",
            input => _instructionBuilder.BuildInstruction(input));

        robot2.ChangeSpot(instruction2);
    }

}