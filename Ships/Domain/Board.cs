using Ships.Helpers;
using System.Text;

namespace Ships
{
    public class Board
    {
        public int Size { get; private set; }
        Field[,] Fields { get; set; }
        List<Ship> Ships { get; set; }

        public bool AllShipsDestroyed()
        {
            return Ships.All(x => x.Destroyed);
        }

        public static Board Create(int size)
        {
            var board = new Board();
            board.Size = size; 
            board.Ships = new List<Ship>();

            InitializeFields(board, size);
            return board;
        }

        private static void InitializeFields(Board board, int size)
        {
            board.Fields = new Field[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    board.Fields[x, y] = new Field();
                }
            }
        }

        public HitResult RegisterHit(string? coordinatesString)
        {
            if (coordinatesString == null)
                throw new ArgumentNullException(nameof(coordinatesString));
            try
            {
                var coordinates = CoordinatesHelper.MapStringToCoordinates(coordinatesString);

                if(coordinates.X > Size || coordinates.Y > Size)
                    throw new ArgumentNullException(nameof(coordinatesString));

                var hitField = Fields[coordinates.X - 1, coordinates.Y - 1];

                return ResolveHitType(hitField);
            }
            catch (Exception)
            {
                return HitResult.Invalid;
            }
        }

        public bool IsShipOnField(Coordinates coordinates)
        {
            // -1 because coordinates start from 1
            var field = Fields[coordinates.X - 1, coordinates.Y - 1];
            return field.Ship != null;
        }

        public HitResult ResolveHitType(Field hitField)
        {
            if (hitField.Type == FieldType.Ship)
            {
                hitField.Type = FieldType.ShipHit;
                var ship = hitField.Ship;

                ship.Durabiity--;

                if (ship.Durabiity == 0)
                {
                    ship.Destroyed = true;
                    return HitResult.Sink;
                }
                return HitResult.Hit;

            }
            else if (hitField.Type == FieldType.Empty)
            {
                hitField.Type = FieldType.EmptyHit;
                return HitResult.Miss;
            }
            return HitResult.Invalid;
        }

        public void PlaceShip(Direction direction, Coordinates coordinates, int length)
        {
            var ship = new Ship(length);
            for (int i = 0; i < length; i++)
            {
                Coordinates newCoordinates;
                if (direction == Direction.Horizontal)
                    newCoordinates = new Coordinates(coordinates.X + i, coordinates.Y );
                else
                    newCoordinates = new Coordinates(coordinates.X, coordinates.Y + i);
                PlaceShipOnField(newCoordinates, ship);
            }
        }

        private void PlaceShipOnField(Coordinates coordinates, Ship ship)
        {
            var field = Fields[coordinates.X - 1, coordinates.Y - 1];
            field.Ship = ship;
            field.Type = FieldType.Ship;
            Ships.Add(ship);
        }

        public void PrintBoard()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("  ");
            for (int y = 0; y < Size; y++) { 
                stringBuilder.Append( $"{y + 1} ");
            }
            stringBuilder.AppendLine();
            for (int x = 0; x < Size; x++)
            {
                string line = $"{CoordinatesHelper.IntToString(x)} ";

                for (int y = 0; y < Size; y++)
                {
                    var field = Fields[x, y];
                    if(field.Type == FieldType.Empty)
                        line += "O ";
                    else if(field.Type == FieldType.Ship)
                        line += "O ";
                    else if (field.Type == FieldType.ShipHit)
                        line += "H ";
                    else if (field.Type == FieldType.EmptyHit)
                        line += "X ";
                }
                stringBuilder.AppendLine(line);
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
