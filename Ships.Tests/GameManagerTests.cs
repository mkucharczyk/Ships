using Xunit;

namespace Ships.Tests
{
    public class GameManagerTests
    {
        [Theory]
        [InlineData(10, 1, 1)]
        [InlineData(10, 1, 0)]
        [InlineData(15, 0, 0)]
        [InlineData(20, 2, 2)]
        [InlineData(25, 3, 2)]
        public void InitializeGame_ThrowsNoExceptions(int size, int numberOfDestroyers, int numberOfBattleships)
        {
            var gameManager = new GameManager(size);

            gameManager.InitializeGame(numberOfDestroyers, numberOfBattleships);
        }
    }
}
