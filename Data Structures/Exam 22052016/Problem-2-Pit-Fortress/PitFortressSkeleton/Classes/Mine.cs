namespace Classes
{
    using Interfaces;

    public class Mine : IMine
    {
        public Mine(int id, Player player, int xCoordinate, int delay, int damage)
        {
            this.Id = id;
            this.Delay = delay;
            this.Damage = damage;
            this.XCoordinate = xCoordinate;
            this.Player = player;
        }

        public int CompareTo(Mine other)
        {
            int cmp = this.Delay.CompareTo(other.Delay);

            if (cmp == 0)
            {
                cmp = this.Id.CompareTo(other.Id);
            }

            return cmp;
        }

        public int Id { get; private set; }

        public int Delay { get; set; }

        public int Damage { get; private set; }

        public int XCoordinate { get; private set; }

        public Player Player { get; private set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, Player: {this.Player.Name}, Radius: {this.Player.Radius}";
        }
    }
}
