using RW.Builders.Interfaces;
using RW.Entities;

namespace RW.Builders;

public class RobotBuilder : IRobotBuilder
{
    public Robot BuildRobot(Arena arena, string location)
    {
        var spotBuilder = new SpotBuilder();
        var robotLocation = spotBuilder.BuildSpot(location);
        var robot = new Robot(ref arena, robotLocation);

        ConsoleManager.Print("ROBOT POSITION: " + $"{robot.Spot.Coordinates.X} {robot.Spot.Coordinates.Y} {(char)robot.Spot.Direction}");

        return robot;
    }
}