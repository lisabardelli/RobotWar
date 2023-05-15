using RW.Builders.Interfaces;
using RW.Entities;

namespace RW.Builders;

public class RobotBuilder: IRobotBuilder
{
    public Robot BuildRobot( Arena arena, string location)
    {
        var spotBuilder = new SpotBuilder();
        var robotLocation = spotBuilder.BuildSpot(location);
        
        if (!arena.IsSpotInsideArena(robotLocation.Coordinates))
        {
            throw new Exception("Spot outside of arena");
        }
        
        if (arena.IsSpotAlreadyTaken(robotLocation.Coordinates))
        {
            throw new Exception("Spot is already taken.");
        }
        
        var robot = new Robot(arena, robotLocation);
        
        ConsoleManager.Print(null, robot.Spot);
      
        return robot;
    }
}