using RW.Entities;
using RW.Entities.Spot;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests;

public class RobotTests
{
    private readonly Arena _arena;
    private readonly Spot _spot;
    private readonly Robot _robot;

    public RobotTests()
    {
        _arena = new Arena("5");
        _spot = new Spot { Coordinates = new Coordinates(1,2), Direction = CardinalPoint.North };
        _robot = new Robot(_arena, _spot);
    }

    [Fact]
    public void ChangeSpot_Should_Move_Or_Rotate_AndMarkNewSpotAsTaken()
    {
        // Arrange
        var instruction = new Instruction(new[] { "L", "M", "L", "M", "L", "M", "L", "M", "M" });
  
        // Act
        var newSpot = _robot.ChangeSpot(instruction, _spot, _arena);

        // Assert
        Assert.Equal(1, newSpot.Coordinates.X);
        Assert.Equal(3, newSpot.Coordinates.Y);
        Assert.Equal(CardinalPoint.North, newSpot.Direction);
    }

    [Fact]
    public void ChangeSpot_Should_NotMoveRobot_When_NextSpotIsTaken()
    {
        // Arrange
        var instruction = new Instruction(new[] { "M", "M" });
        _arena.SquaresTaken.Add(new Coordinates(1,3));
        
        // Act
        var newSpot = _robot.ChangeSpot(instruction, _spot, _arena);

        // Assert
        Assert.Equal(1, newSpot.Coordinates.X);
        Assert.Equal(2, newSpot.Coordinates.Y);
        Assert.Equal(CardinalPoint.North, newSpot.Direction);
    }
    
    [Fact]
    public void ChangeSpot_Should_Move_Or_Rotate_Robot_Until_NextSpotIsTaken()
    {
        // Arrange
        var instruction = new Instruction( new [] {"M", "M", "M", "M"});
        _arena.SquaresTaken.Add(new Coordinates(1,4));
        
        // Act
        var newSpot = _robot.ChangeSpot(instruction, _spot, _arena);

        // Assert
        Assert.Equal(1, newSpot.Coordinates.X);
        Assert.Equal(3, newSpot.Coordinates.Y);
        Assert.Equal(CardinalPoint.North, newSpot.Direction);
    }
}