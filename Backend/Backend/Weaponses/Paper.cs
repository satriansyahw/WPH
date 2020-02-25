using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Weaponses
{
    public class Paper : WeaponInfo, IWeaponsVS
    {
        public Paper()
        {
            this.Name = "Paper";
        }
        public bool IsWinWeapons(Type typeEnemyweapons)
        {
            // WeaponPaper only win over WeaponRock
            if (typeEnemyweapons == typeof(Rock))
                return true;
            else
                return false;
        }
    }
}
