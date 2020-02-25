using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Weaponses
{
    public class Rock : WeaponInfo, IWeaponsVS
    {
        public Rock()
        {
            this.Name = "Rock";
        }
        public bool IsWinWeapons(Type typeEnemyweapons)
        {
            // WeaponRock only win over WeaponScissors
            if (typeEnemyweapons == typeof(Scissor))
                return true;
            else
                return false;
        }
    }
}
