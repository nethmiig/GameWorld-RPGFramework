namespace Game_World
{
    public class Armor : Item
    {
        public int Defense { get; set; }
        public int Durability { get; set; }

        // Corrected constructor to include the "itemType" parameter
        public Armor(string name, ItemRarity rarity, int defense, int durability)
            : base(name, rarity, "Armor") 
        {
            Defense = defense;
            Durability = durability;
        }

        // Override DisplayStats to display the armor's stats
        public override void DisplayStats()
        {
            Console.WriteLine($"Armor: {Name} | Rarity: {Rarity} | Defense: {Defense} | Durability: {Durability}");
        }

       
    }
}
