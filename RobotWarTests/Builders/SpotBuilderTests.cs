using RW.Builders;
using RW.Entities.Spot;
using Xunit;
using Assert = Xunit.Assert;
namespace RobotWarTests.Builders;

public class SpotBuilderTests
{
    private readonly SpotBuilder _spotBuilder;

    public SpotBuilderTests()
    {
        _spotBuilder = new SpotBuilder();
    }

    [Fact]
    public void BuildSpot_ValidLocation_ReturnsSpotObjectWithCorrectCoordinatesAndDirection()
    {
        // Arrange
        var validLocation = "2 3 N";

        // Act
        var spot = _spotBuilder.BuildSpot(validLocation);

        // Assert
        Assert.NotNull(spot);
        Assert.Equal(2, spot.Coordinates.X);
        Assert.Equal(3, spot.Coordinates.Y);
        Assert.Equal(CardinalPoint.North, spot.Direction);
    }

    [Fact]
    public void BuildSpot_InvalidLocation_ThrowsArgumentException()
    {
        // Arrange
        var invalidLocation = "2X 3 N";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _spotBuilder.BuildSpot(invalidLocation));
    }
}