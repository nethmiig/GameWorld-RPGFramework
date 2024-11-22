namespace Game_World
{
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public WeaponTypeEnum WeaponType { get; set; }

        public Weapon(string name, ItemRarity rarity, int damage, WeaponTypeEnum weaponType)
            : base(name, rarity, "Weapon")
        {
            Damage = damage;
            WeaponType = weaponType;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"Weapon: {Name} | Rarity: {Rarity} | Damage: {Damage} | Type: {WeaponType}");
        }
    }

   
}
