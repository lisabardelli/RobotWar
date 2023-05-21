using RW.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests;

public class ArenaTests
{
    [Fact]
    public void IsSpotAlreadyTaken_Should_Return_True_If_Square_Is_Already_Taken()
    {
        // Arrange
        var arena = new Arena(5);
        var coordinates = new Coordinates(2, 3);
        arena.TakeSpot(coordinates);

        // Act
        var result = arena.IsSpotAlreadyTaken(coordinates);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsSpotAlreadyTaken_Should_Return_False_If_Square_Is_Not_Taken()
    {
        // Arrange
        var arena = new Arena(5);
        var coordinates = new Coordinates(2, 3);

        // Act
        var result = arena.IsSpotAlreadyTaken(coordinates);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsSpotInsideArena_Should_Return_True_If_Coordinates_Are_Inside_Arena()
    {
        // Arrange
        var arena = new Arena(5);

        // Act
        var result = arena.IsSpotInsideArena(new Coordinates(2, 3));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsSpotInsideArena_Should_Return_False_If_Coordinates_Are_Outside_Arena()
    {
        // Arrange
        var arena = new Arena(5);

        // Act
        var result = arena.IsSpotInsideArena(new Coordinates(6, 7));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TakeSpot_When_Spot_Is_Already_Taken_ShouldThrowException()
    {
        // Arrange
        var arena = new Arena(5);
        var coordinates = new Coordinates(2, 3);
        arena.TakeSpot(coordinates);

        // Act and Assert
        Assert.Throws<Exception>(() => arena.TakeSpot(coordinates));
    }

    [Fact]
    public void TakeSpot_When_Spot_Is_Outside_Arena_ShouldThrowException()
    {
        // Arrange
        var arena = new Arena(5);
        var coordinates = new Coordinates(7, 8);

        // Act and Assert
        Assert.Throws<Exception>(() => arena.TakeSpot(coordinates));
    }

    [Fact]
    public void RemoveSquare_When_Spot_Is_Not_Taken_ShouldThrowException()
    {
        // Arrange
        var arena = new Arena(5);
        var coordinates = new Coordinates(2, 3);

        // Act and Assert
        Assert.Throws<Exception>(() => arena.RemoveSquare(coordinates));
    }
}