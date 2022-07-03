using Xunit;

namespace Ships.Tests
{
    public class BoardTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(15)]
        [InlineData(20)]
        public void BoardCreate_Creates_BoardOfRightSize(int size)
        {
            var board = Board.Create(size);

            Assert.Equal(size, board.Size);
        }
    }
}
