namespace Ships
{
    public class ShipGenerator
    {
        public static Coordinates GenerateCoordinates(int maxX, int maxY)
        {
            Random random = new Random();

            return new Coordinates(random.Next(1, maxX), random.Next(1, maxY));
        }

        private static (Direction?,Coordinates?) CheckIfShipCanBePlaced(Board board, int length)
        {
            foreach (Direction direction in GetRandomizedDirections())
            {
                var coordinates = direction == Direction.Horizontal ? GenerateCoordinates(board.Size - length, board.Size) : GenerateCoordinates(board.Size, board.Size - length);
                var collision = false;
                for (int i = 1; i <= length; i++)
                {
                    Coordinates newCoordinates;
                    if (direction == Direction.Horizontal)
                        newCoordinates = new Coordinates(coordinates.X, coordinates.Y + i);
                    else
                        newCoordinates = new Coordinates(coordinates.X + i, coordinates.Y);
                    if (board.IsShipOnField(newCoordinates))
                    {
                        collision = true;
                    }
                    break;
                }
                if (collision)
                    break;
                else
                    return (direction, coordinates);
            }
            return (null, null);
        }

        private static IEnumerable<Direction> GetRandomizedDirections()
        {
            var directions = Enum.GetValues<Direction>().ToList();
            var rnd = new Random();
            return directions.OrderBy(item => rnd.Next());
        }

        public static void CreateShip(Board board, ShipType shipType)
        {
            var length = shipType == ShipType.Battleship ? 5 : 4;

            var created = false;
            while (!created)
            {
                var (direction, coordinates) = CheckIfShipCanBePlaced(board, length);
                if (direction.HasValue)
                {
                    board.PlaceShip(direction.Value, coordinates, length);
                    created = true;
                }
            }
        }
    }
}
