using Ships.Helpers;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Ships.Tests
{
    public class CoordinatesHelperTests
    {
        [Theory]
        [ClassData(typeof(CoordinatesHelperTestsData))]
        public void GenerateCoordinates_Returns_Coordinates(string coordinatesString, Coordinates result)
        {
            var coordinates = CoordinatesHelper.MapStringToCoordinates(coordinatesString);

            Assert.Equal(result.X, coordinates.X);
            Assert.Equal(result.Y, coordinates.Y);
        }


        public class CoordinatesHelperTestsData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { "A5", new Coordinates(1, 5) };
                yield return new object[] { "B6", new Coordinates(2, 6) };
                yield return new object[] { "G3", new Coordinates(7, 3) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
