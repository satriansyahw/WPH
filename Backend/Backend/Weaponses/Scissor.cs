using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Weaponses
{
    public class Scissor : WeaponInfo, IWeaponsVS
    {
        public Scissor()
        {
            this.Name = "Scissor";
        }
        public bool IsWinWeapons(Type typeEnemyweapons)
        {
            // WeaponScissors only win over WeaponPaper
            if (typeEnemyweapons == typeof(Paper))
                return true;
            else
                return false;
        }
    }
}
