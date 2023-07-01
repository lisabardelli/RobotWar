using RW.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests;

public class RobotTests
{
    private readonly Arena _arena;
    private readonly Robot _robot;

    public RobotTests()
    {
        _arena = new Arena(5);
        var spot = new Spot { Coordinates = new Coordinates(1, 2), Direction = CardinalPoint.North };
        _robot = new Robot(ref _arena, spot);
    }

    [Fact]
    public void ChangeSpot_Should_Move_Or_Rotate_AndMarkNewSpotAsTaken()
    {
        // Arrange
        var instruction = new Instruction(new[] { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' });

        // Act
        _robot.ChangeSpot(instruction);

        // Assert
        Assert.Equal(1, _robot.Spot.Coordinates.X);
        Assert.Equal(3, _robot.Spot.Coordinates.Y);
        Assert.Equal(CardinalPoint.North, _robot.Spot.Direction);
        Assert.True(_arena.IsSpotAlreadyTaken(new Coordinates(1, 3)));
    }

    [Fact]
    public void ChangeSpot_Should_NotMoveRobot_When_NextSpotIsTaken()
    {
        // Arrange
        var instruction = new Instruction(new[] { 'M', 'M' });
        _arena.TakeSpot(new Coordinates(1, 3));

        // Act
        _robot.ChangeSpot(instruction);

        // Assert
        Assert.Equal(1, _robot.Spot.Coordinates.X);
        Assert.Equal(2, _robot.Spot.Coordinates.Y);
        Assert.Equal(CardinalPoint.North, _robot.Spot.Direction);
    }

    [Fact]
    public void ChangeSpot_Should_Move_Or_Rotate_Robot_Until_NextSpotIsTaken()
    {
        // Arrange
        var instruction = new Instruction(new[] { 'M', 'M', 'M', 'M' });
        _arena.TakeSpot(new Coordinates(1, 4));

        // Act
        _robot.ChangeSpot(instruction);

        // Assert
        Assert.Equal(1, _robot.Spot.Coordinates.X);
        Assert.Equal(3, _robot.Spot.Coordinates.Y);
        Assert.Equal(CardinalPoint.North, _robot.Spot.Direction);
    }
}