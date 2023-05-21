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
    [InlineData("123")]
    [InlineData("456")]
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
        Assert.Equal("Input cannot be empty.", result.Errors[0].ErrorMessage);
    }

    [Fact]
    public void Validate_WhenInputIsNotValidInteger_ShouldHaveValidationErrorMessage()
    {
        // Arrange
        var input = "abc";

        // Act
        var result = _validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal("Input must be a valid integer and greater than 0.", result.Errors[0].ErrorMessage);
    }

    [Fact]
    public void Validate_WhenInputIsNotGreaterThanZero_ShouldHaveValidationErrorMessage()
    {
        // Arrange
        var input = "0";

        // Act
        var result = _validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal("Input must be a valid integer and greater than 0.", result.Errors[0].ErrorMessage);
    }
}