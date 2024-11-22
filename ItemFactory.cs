using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public interface ItemFactory
    {
        Weapon CreateWeapon(string name, WeaponTypeEnum weaponType);
        Potion CreatePotion(string name, string effect);
        Armor CreateArmor(string name, int defense);
    }
}
