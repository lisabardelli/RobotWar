using RW.Builders;
using RW.Builders.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests.Builders;

public class InstructionBuilderTests
{
    private readonly IInstructionBuilder _instructionBuilder;

    public InstructionBuilderTests()
    {
        _instructionBuilder = new InstructionBuilder();
    }

    [Fact]
    public void BuildInstruction_ValidInstruction_ReturnsInstructionObject()
    {
        // Arrange
        var validInstruction = "MMRL";

        // Act
        var instruction = _instructionBuilder.BuildInstruction(validInstruction);

        // Assert
        Assert.NotNull(instruction);
        Assert.Equal(validInstruction.Length, instruction.NavigationInput.Length);
    }

    [Fact]
    public void BuildInstruction_InvalidInstruction_ThrowsArgumentException()
    {
        // Arrange
        var invalidInstruction = "ABC";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _instructionBuilder.BuildInstruction(invalidInstruction));
    }
}