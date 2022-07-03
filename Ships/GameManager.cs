namespace Ships
{
    public class GameManager
    {
        Board board;

        public GameManager(int size)
        {
            board = Board.Create(size);

        }

        public void InitializeGame(int numberOfDestroyers, int numberOfBattleships)
        {
            for (int i = 0; i < numberOfDestroyers; i++)
            {
                ShipGenerator.CreateShip(board, ShipType.Destroyer);
            }
            for (int i = 0; i < numberOfBattleships; i++)
            {
                ShipGenerator.CreateShip(board, ShipType.Battleship);
            }
            board.PrintBoard();
        }

        public void GameLoop()
        {
            Console.WriteLine("Enter hit coordinates eg. A5");
            var coordinates = Console.ReadLine();
            var result = board.RegisterHit(coordinates);
            Console.Clear();
            board.PrintBoard();
            Console.WriteLine($"Result of shot is: {result}");
        }

        public bool IsGameOver()
        {
            return board.AllShipsDestroyed();
        }

        public void GameOver()
        {
            Console.WriteLine("Good job! You have beaten the game");
        }
    }
}
