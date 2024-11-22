namespace Game_World
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string ItemType { get; set; }
        public ItemRarity Rarity { get; set; }

        protected Item(string name, ItemRarity rarity, string itemType)
        {
            Name = name ?? throw new ArgumentException("Name cannot be null.");
            ItemType = itemType ?? throw new ArgumentException("ItemType cannot be null.");
            Rarity = rarity;
        }

        public abstract void DisplayStats();

        public override string ToString()
        {
            return $"{Name} ({ItemType}) - Rarity: {Rarity}";
        }
    }

    public enum ItemRarity
    {
        Common,
        Rare,
        Legendary
    }
}
