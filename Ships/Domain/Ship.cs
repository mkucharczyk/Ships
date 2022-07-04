namespace Ships
{
    public class Ship
    {
        public Ship(int durability)
        {
            Durabiity = durability;
        }

        public int Durabiity { get; set; }
        public bool Destroyed { get; set; } = false;
    }                               
}
