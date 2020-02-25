using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Backend.Weaponses
{
    public interface IGeneralWeapons
    {
        void SetInitialWeapons();
        Dictionary<int, Type> GetAllWeapons();
        string CreateWeaponsList();
        string GetWeaponsName(Type typeWeapon);
        string GetWeaponsName(Dictionary<int, Type> weaponInfo);
        Dictionary<int, Type> GetTypeSelectedWeapons(string input);
        Dictionary<int, Type> GetComputerWeapon(Dictionary<int, Type> userWeaponType);
        bool isPlayerWeaponWin(Dictionary<int, Type> playerWeapon, Dictionary<int, Type> compWepon);

    }
    public interface IWeaponsVS
    {
        bool IsWinWeapons(Type typeEnemyweapons);
    }
    public class GeneralWeapons:IGeneralWeapons
    {
        private static GeneralWeapons instance;
        public Dictionary<int, Type> Weapons= new Dictionary<int, Type>();
        public static GeneralWeapons GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new GeneralWeapons();
                return instance;
            }
        }

        public string CreateWeaponsList()
        {
            string result = string.Empty;
            var weapons = this.GetAllWeapons();
            foreach (var item in weapons)
            {
                string myWeapons = string.Empty;
                myWeapons = this.GetWeaponsName(item.Value);
                result += !string.IsNullOrEmpty(result) ? "," + item.Key.ToString() + "=" + myWeapons : item.Key.ToString() + "=" + myWeapons;

            }
            return result;
        }

        public Dictionary<int, Type> GetAllWeapons()
        {
            return this.Weapons;
        }

        public Dictionary<int, Type> GetComputerWeapon(Dictionary<int, Type> userWeaponType)
        {
            Random random = new Random();
            int userselectid = 0;
            Type typeselected = null;
            Dictionary<int, Type> result = new Dictionary<int, Type>();
            bool loop = true;
            int check = 0;
            foreach (KeyValuePair<int, Type> item in userWeaponType)
            {
                userselectid = item.Key;
                typeselected = item.Value;
                break;
            }
            while (loop)
            {
                check = random.Next(1, 3);
                if (check != userselectid)
                    loop = false;
            }
            var allWeapons = this.GetAllWeapons();
            var Getweapons = allWeapons.Where(a => a.Key.ToString().ToLower() == check.ToString().ToLower()).ToList();
            if (Getweapons != null)
            {
                if (Getweapons.Count() > 0)
                {
                    result.Add(Getweapons[0].Key,Getweapons[0].Value);
                }
            }
            return result;
        }

    

        public Dictionary<int, Type> GetTypeSelectedWeapons(string input)
        {
            input = input.ToString().Trim().ToLower();
            Dictionary<int, Type> result = new Dictionary<int, Type>();
            var allWeapons = this.GetAllWeapons();
            var checkBykey = allWeapons.Where(a => a.Key.ToString().ToLower() == input).ToList();
           
            if (checkBykey != null)
            {
                if (checkBykey.Count() > 0)
                {
                    result.Add(checkBykey[0].Key, checkBykey[0].Value);
                    return result;
                }
            }
            var checkByvalue = allWeapons.Where(a => a.Value.Name.ToString().ToLower() == input).ToList();
            if (checkByvalue != null)
            {
                if (checkByvalue.Count() > 0)
                {
                    result.Add(checkByvalue[0].Key, checkByvalue[0].Value);
                    return result;
                }
            }
            return null;

        }

        public string GetWeaponsName(Type typeWeapon)
        {
            WeaponInfo weapon = null;
            string result = string.Empty;
           if(typeWeapon== typeof(Paper))
            {
                 weapon = new Paper();

            }
           else if (typeWeapon == typeof(Rock))
            {
                weapon = new Rock();
            }
            else 
            {
                weapon = new Scissor();
            }
            result = weapon.Name;
            return result;
        }

        public string GetWeaponsName(Dictionary<int, Type> weaponInfo)
        {
            Type type = null;
            foreach (KeyValuePair<int, Type> item in weaponInfo)
            {
                type = item.Value;
                break;
            }
            return GetWeaponsName(type);
        }

        public bool isPlayerWeaponWin(Dictionary<int, Type> playerWeapon, Dictionary<int, Type> compWepon)
        {
            Type typePlayer = null;
            Type typeComp = null;
            bool result = false;
            foreach (KeyValuePair<int, Type> item in playerWeapon)
            {
                typePlayer = item.Value;
                break;
            }
            foreach (KeyValuePair<int, Type> item in compWepon)
            {
                typeComp = item.Value;
                break;
            }
            if (typePlayer == typeof(Paper))
            {
                Paper weapon = new Paper();
                result =weapon.IsWinWeapons(typeComp);

            }
            else if (typePlayer == typeof(Rock))
            {
                Rock weapon = new Rock();
                result = weapon.IsWinWeapons(typeComp);
            }
            else
            {
                Scissor  weapon = new Scissor();
                result = weapon.IsWinWeapons(typeComp);
            }

            return result;

        }

        public void SetInitialWeapons()
        {
            Weapons.Add(1,typeof(Rock));
            Weapons.Add(2, typeof(Paper));
            Weapons.Add(3, typeof(Scissor));
        }
    }
    
    
    
    public class WeaponInfo
    {
        public string Name { get; set; }
    }

}
