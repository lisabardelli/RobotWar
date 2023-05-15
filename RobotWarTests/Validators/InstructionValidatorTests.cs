using RW.Entities;
using RW.Validators;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests.Validators;

public class InstructionValidatorTests
{
    private readonly InstructionValidator _validator;

    public InstructionValidatorTests()
    {
        _validator = new InstructionValidator();
    }

    [Theory]
    [InlineData("L", "M", "R")]
    [InlineData("l", "M", "R")]
    public void NavigationInput_ShouldOnlyContain_L_M_R(params string[] instructions)
    {
        // Arrange
        var instruction = new Instruction(instructions);

        // Act
        var result = _validator.Validate(instruction);

        // Assert
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("L", "M", "T")]
    [InlineData("L", "K", "M", "R", "R", "M")]
    [InlineData("T")]
    [InlineData("t")]
    public void NavigationInput_ContainsInvalidInstructions_ShouldThrowException(params string[] instructions)
    {
        // Arrange
        var instruction = new Instruction(instructions);

        // Act
        var result = _validator.Validate(instruction);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal("Please only use: L,M,R", result.Errors.First().ErrorMessage);
    }
    
}
