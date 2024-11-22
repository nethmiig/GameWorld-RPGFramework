namespace Game_World
{
    public class Slime : Enemy
    {
        public Slime(string name, string rank, int health, int mana, int strength, int agility)
            : base(name, rank)
        {
            Health = health;
            Mana = mana;
            Strength = strength;
            Agility = agility;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} slithers slowly.");
        }
    }
}
