using RW.Builders;
using RW.Builders.Interfaces;
using RW.Entities;

namespace RW;

public static class Program
{
    static void Main(string[] arg)
            {
                IArenaBuilder arenaBuilder = new ArenaBuilder();
                IRobotBuilder robotBuilder = new RobotBuilder();
                InstructionBuilder instructionBuilder = new InstructionBuilder();
                var gameManager = new GameManager(arenaBuilder, robotBuilder, instructionBuilder);

                var arena = gameManager.CreateArena();
                IRobot robot1 = gameManager.CreateRobot(arena);
                var instruction1 = gameManager.CreateInstruction();
    
                robot1.ChangeSpot(instruction1);
    
                IRobot robot2 = gameManager.CreateRobot(arena);
                var instruction2 = gameManager.CreateInstruction();
    
                robot2.ChangeSpot(instruction2);
            }
}