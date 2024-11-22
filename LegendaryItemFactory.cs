using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class LegendaryItemFactory : ItemFactory
    {
        public Weapon CreateWeapon(string name, WeaponTypeEnum weaponType)
        {
            return new Weapon(name, ItemRarity.Legendary, 100, weaponType);
        }

        public Potion CreatePotion(string name, string effect)
        {
            return new Potion(name, ItemRarity.Legendary, effect, 30);
        }

        public Armor CreateArmor(string name, int defense)
        {
            return new Armor(name, ItemRarity.Legendary, defense, 100);
        }
    }
}
