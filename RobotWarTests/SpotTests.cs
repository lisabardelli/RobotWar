
using RW.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests
{
    public class SpotTests
    {
        [Fact]
        public void Spot_WithPreviousSpot_ShouldCopyCoordinatesAndDirection()
        {
            // Arrange
            var previousCoordinates = new Coordinates(2, 3);
            var previousDirection = CardinalPoint.North;
            var previousSpot = new Spot(previousCoordinates, previousDirection);

            // Act
            var spot = new Spot(previousSpot);

            // Assert
            Assert.Equal(previousCoordinates, spot.Coordinates);
            Assert.Equal(previousDirection, spot.Direction);
        }

        [Fact]
        public void Spot_WithCoordinatesAndDirection_ShouldSetCoordinatesAndDirection()
        {
            // Arrange
            var coordinates = new Coordinates(4, 5);
            var direction = CardinalPoint.East;

            // Act
            var spot = new Spot(coordinates, direction);

            // Assert
            Assert.Equal(coordinates, spot.Coordinates);
            Assert.Equal(direction, spot.Direction);
        }

        [Fact]
        public void Spot_DefaultConstructor_ShouldSetCoordinatesToNull()
        {
            // Arrange

            // Act
            var spot = new Spot();

            // Assert
            Assert.Null(spot.Coordinates);
        }
    }
}