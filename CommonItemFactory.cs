using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class CommonItemFactory : ItemFactory
    {
        public Weapon CreateWeapon(string name, WeaponTypeEnum weaponType)
        {
            return new Weapon(name, ItemRarity.Common, 10, weaponType);
        }

        public Potion CreatePotion(string name, string effect)
        {
            return new Potion(name, ItemRarity.Common, effect, 5);
        }

        public Armor CreateArmor(string name, int defense)
        {
            return new Armor(name, ItemRarity.Common, defense, 10);
        }
    }
}
