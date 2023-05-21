using RW.Builders;
using RW.Builders.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests.Builders;

public class ArenaBuilderTests
{
    private readonly IArenaBuilder _arenaBuilder;

    public ArenaBuilderTests()
    {
        _arenaBuilder = new ArenaBuilder();
    }

    [Theory]
    [InlineData("L")]
    [InlineData("")]
    [InlineData(" ")]
    public void BuildArena_Should_Throw_Exception_If_Input_Is_Not_An_Integer(string topRightCorner)
    {
        // Assert
        Assert.Throws<Exception>(() => _arenaBuilder.BuildArena(topRightCorner));
    }

    [Fact]
    public void BuildArena_Should_Build_Arena()
    {
        // Act
        var arena = _arenaBuilder.BuildArena("5");
        // Assert
        Assert.Equal(5, arena.TopCorner.X);
        Assert.Equal(5, arena.TopCorner.Y);
        Assert.Equal(0, arena.BottomCorner.X);
        Assert.Equal(0, arena.BottomCorner.Y);
    }
}