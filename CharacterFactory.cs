using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class CharacterFactory
    {
        public static Character CreateCharacter(string type, string name)
        {
            return type.ToLower() switch
            {
                "warrior" => new Warrior(name),
                "mage" => new Mage(name),
                "archer" => new Archer(name),
                _ => throw new ArgumentException("Invalid character type")
            };
        }
    }
}
