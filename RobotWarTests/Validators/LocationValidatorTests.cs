using RW.Validators;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests.Validators;

public class LocationValidatorTests
{
    private readonly LocationValidator _validator;

    public LocationValidatorTests()
    {
        _validator = new LocationValidator();
    }

    [Fact]
    public void Validate_ShouldPass_WhenInputIsValid()
    {
        // Act
        var result = _validator.Validate("1 2 N");

        // Assert
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("t")]
    [InlineData("1 2")]
    [InlineData("1")]
    [InlineData("1 2 n N")]
    public void Validate_ShouldFail_WhenInputHasNotTheRightLength(string input)
    {
        // Act
        var result = _validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("Input must contain three elements", result.Errors[0].ErrorMessage);
    }

    [Fact]
    public void Validate_ShouldFail_WhenFirstElementIsInvalid()
    {
        // Act
        var result = _validator.Validate("t 2 N");

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("The first element of location must be an integer greater than 0.", result.Errors[0].ErrorMessage);
    }

    [Fact]
    public void Validate_ShouldFail_WhenSecondElementIsInvalid()
    {
        // Act
        var result = _validator.Validate("1 t N");

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("The second element of location must be an integer greater than 0.", result.Errors[0].ErrorMessage);
    }

    [Fact]
    public void Validate_ShouldFail_WhenThirdElementIsInvalid()
    {
        // Act
        var result = _validator.Validate("1 2 f");

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("The third element of location must be a cardinal point (N, S, E or W).", result.Errors[0].ErrorMessage);
    }
}