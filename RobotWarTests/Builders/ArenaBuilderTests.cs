using FluentValidation;
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

    [Fact]
    public void BuildArena_Should_Build_Arena()
    {
        // Act
        var arena = _arenaBuilder.BuildArena("5 5");

        Assert.NotNull(arena);
    }
    
    [Theory]
    [InlineData("L")]
    [InlineData("0")]
    [InlineData("")]
    [InlineData(" ")]
    public void BuildArena_Should_Throw_Exception_If_Input_Is_Not_An_Integer(string topRightCorner)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => _arenaBuilder.BuildArena(topRightCorner));
    }
}