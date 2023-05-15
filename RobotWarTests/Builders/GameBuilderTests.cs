using RW.Builders;
using RW.Entities.Spot;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests.Builders;

public class GameBuilderTests
{

    [Fact]
    public void CanRunGameBuilder()
    {
        // Arrange
        var arenaBuilder = new ArenaBuilder();
        var robotBuilder = new RobotBuilder();
        var instructionBuilder = new InstructionBuilder();

        // Act
        var arena = arenaBuilder.BuildArena("5");
        var robot1 = robotBuilder.BuildRobot(arena, "1 2 N");
        var instruction1 = instructionBuilder.BuildInstruction("LMLMLMLMM");
        robot1.ChangeSpot(instruction1, robot1.Spot, arena);

        var robot2 = robotBuilder.BuildRobot(arena, "3 3 E");
        var instruction2 = instructionBuilder.BuildInstruction("MMRMMRMRRM");
        robot2.ChangeSpot(instruction2, robot2.Spot, arena);

        // Assert
        Assert.NotNull(robot1);
        Assert.NotNull(robot2);
        Assert.NotNull(instruction1);
        Assert.NotNull(instruction2);
        Assert.Equal(1, robot1.Spot.Coordinates.X);
        Assert.Equal(3, robot1.Spot.Coordinates.Y);
        Assert.Equal(CardinalPoint.North, robot1.Spot.Direction);
        Assert.Equal(5, robot2.Spot.Coordinates.X);
        Assert.Equal(1, robot2.Spot.Coordinates.Y);
        Assert.Equal(CardinalPoint.East, robot2.Spot.Direction);
    }
}
