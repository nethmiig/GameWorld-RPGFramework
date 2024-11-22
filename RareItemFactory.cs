using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class RareItemFactory : ItemFactory
    {
        public Weapon CreateWeapon(string name, WeaponTypeEnum weaponType)
        {
            return new Weapon(name, ItemRarity.Rare, 50, weaponType);
        }

        public Potion CreatePotion(string name, string effect)
        {
            return new Potion(name, ItemRarity.Rare, effect, 15);
        }

        public Armor CreateArmor(string name, int defense)
        {
            return new Armor(name, ItemRarity.Rare, defense, 50);
        }
    }
}
