using RW.Builders;

namespace RW;

public class Program
{
    static void Main(string[] arg)
    {
        var arenaBuilder = new ArenaBuilder();
        var robotBuilder = new RobotBuilder();
        var instructionBuilder = new InstructionBuilder();
        var gameManager = new GameManager(arenaBuilder, robotBuilder, instructionBuilder);
        gameManager.Run();
    }
}
