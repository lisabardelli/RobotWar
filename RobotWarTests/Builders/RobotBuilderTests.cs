using RW.Builders;
using RW.Builders.Interfaces;
using RW.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests.Builders;

public class RobotBuilderTests
{
    private readonly IRobotBuilder _robotBuilder;

    public RobotBuilderTests()
    {
        _robotBuilder = new RobotBuilder();
    }
    [Fact]
    public void BuildRobot_Should_Throw_Exception_If_Location_Is_Outside_Arena()
    {
        // Arrange
        var arena = new Arena(5);
        var location = "6 6 N";

        // Act and Assert
        Assert.Throws<Exception>(() => _robotBuilder.BuildRobot(arena, location));
    }

    [Fact]
    public void BuildRobot_Should_Throw_Exception_If_Location_Is_Already_Taken()
    {
        // Arrange
        var arena = new Arena(5);
        arena.TakeSpot(new Coordinates(2, 3));
        var location = "2 3 N";

        // Act and Assert
        Assert.Throws<Exception>(() => _robotBuilder.BuildRobot(arena, location));
    }

    [Fact]
    public void BuildRobot_Should_Return_New_Robot_If_Location_Is_Valid()
    {
        // Arrange
        var arena = new Arena(5);
        var location = "2 3 N";

        // Act
        var robot = _robotBuilder.BuildRobot(arena, location);

        // Assert
        Assert.NotNull(robot);
        Assert.Equal(2, robot.Spot.Coordinates.X);
        Assert.Equal(3, robot.Spot.Coordinates.Y);
        Assert.Equal('N', (char)robot.Spot.Direction);
    }
}
