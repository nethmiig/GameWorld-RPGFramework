namespace Game_World
{
    public class DefensiveItem : Item
    {
        public int Defense { get; set; }

        public DefensiveItem(string name, ItemRarity rarity, int defense)
            : base(name, rarity, "Defensive Item")
        {
            Defense = defense;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"Defensive Item: {Name} | Rarity: {Rarity} | Defense: {Defense}");
        }
    }
}
