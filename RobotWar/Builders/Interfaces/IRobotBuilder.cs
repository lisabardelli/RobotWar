using RW.Entities;

namespace RW.Builders.Interfaces;
public interface IRobotBuilder
{
    Robot BuildRobot(Arena arena, string location);
}