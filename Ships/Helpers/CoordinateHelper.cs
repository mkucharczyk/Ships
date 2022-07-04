namespace Ships.Helpers
{
    public class CoordinatesHelper
    {
        public static Coordinates MapStringToCoordinates(string coordinatesString)
        {
            if (String.IsNullOrEmpty(coordinatesString) || coordinatesString.Length > 3)
                throw new ArgumentException("Invalid coordinates string");

            try
            {
                var x = coordinatesString[0] - 64;
                var y = coordinatesString.Length == 3 ? Int32.Parse(coordinatesString.Substring(1, 2)) : coordinatesString[1] - 48;
                return new Coordinates(x, y);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid coordinates string");
            }
        }

        public static char IntToString(int number)
        {
            return Convert.ToChar(65 + number);
        }
    }
}


