using Xunit;

namespace Ships.Tests
{
    public class ShipGeneratorTests
    {
        public ShipGeneratorTests()
        {
        }

        [Theory]
        [InlineData(10, 8)]
        [InlineData(50 , 7)]
        [InlineData(100, 40)]
        public void GenerateCoordinates_Returns_Coordinates(int maxX,int maxY)
        {
            var coordinates = ShipGenerator.GenerateCoordinates(maxX, maxY);

            Assert.NotEqual(0, coordinates.Y);
            Assert.NotEqual(0, coordinates.X);
        }
    }
}
