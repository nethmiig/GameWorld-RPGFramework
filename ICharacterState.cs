using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public interface ICharacterState
    {
        void HandleState(Character character);
    }
}
