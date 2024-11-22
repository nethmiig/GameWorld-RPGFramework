﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class Dragon : Enemy
    {
        public Dragon(string name, string rank, int health, int mana, int strength, int agility)
            : base(name, rank)
        {
            Health = health;
            Mana = mana;
            Strength = strength;
            Agility = agility;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} flies majestically through the air.");
        }
    }
}