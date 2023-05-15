using RW.Entities.Spot;
using Xunit;
using Assert = Xunit.Assert;

namespace RobotWarTests
{
    public class SpotTests
    {
        [Fact]
        public void Move_ShouldChangeCoordinates()
        {
            // Arrange
            var spot = new Spot(new Coordinates(1, 1), CardinalPoint.North);

            // Act
            var result = spot.Move();

            // Assert
            Assert.Equal(2, result.Coordinates.Y);
        }

        [Fact]
        public void RotateLeft_ShouldRotateLeft()
        {
            // Arrange
            var spot = new Spot(new Coordinates(1, 1), CardinalPoint.North);

            // Act
            var result = spot.RotateLeft();

            // Assert
            Assert.Equal(CardinalPoint.West, result);
        }

        [Fact]
        public void RotateRight_ShouldRotateRight()
        {
            // Arrange
            var spot = new Spot(new Coordinates(1, 1), CardinalPoint.North);

            // Act
            var result = spot.RotateRight();

            // Assert
            Assert.Equal(CardinalPoint.East, result);
        }
    }
}