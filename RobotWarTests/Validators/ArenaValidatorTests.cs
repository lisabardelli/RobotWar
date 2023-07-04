using RW.Validators;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests.Validators;

public class ArenaValidatorTests
{
    private readonly ArenaValidator _validator;

    public ArenaValidatorTests()
    {
        _validator = new ArenaValidator();
    }

    [Theory]
    [InlineData("123 45")]
    [InlineData("456 78")]
    public void Validate_ShouldPass_WhenInputIsValid(string input)
    {
        // Act
        var result = _validator.Validate(input);

        // Assert

        Assert.True(result.IsValid);
    }


    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("0")]
    [InlineData("-123")]
    public void Validate_ShouldFail_WhenInputIsNotValid(string input)
    {
        // Act
        var result = _validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validate_WhenInputIsEmpty_ShouldHaveValidationErrorMessage()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = _validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal("Input must contain two elements.", result.Errors[0].ErrorMessage);
    }

    [Theory]
    [InlineData("abc 5")]
    [InlineData("0 5")]
    [InlineData("5.5 5")]
    [InlineData("-5 5")]
    [InlineData("-5 -5")]
    public void Validate_WhenFirstInputIsNotValidInteger_ShouldHaveValidationErrorMessage(string input)
    {
        // Arrange

        // Act
        var result = _validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal("The right coordinate of the top corner of the Arena must be an integer greater than 0.", result.Errors[0].ErrorMessage);
    }

    [Theory]
    [InlineData("5 abc")]
    [InlineData("5 0")]
    [InlineData("5 5.5")]
    [InlineData("5 -5")]
    public void Validate_WhenSecondInputIsNotValidInteger_ShouldHaveValidationErrorMessage(string input)
    {
        // Arrange

        // Act
        var result = _validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal("The left coordinate of the top corner of the Arena must be an integer greater than 0.", result.Errors[0].ErrorMessage);
    }
}