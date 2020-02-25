using Backend.User.Comp;
using Backend.User.Human;
using Backend.Weaponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    public interface IPlayThegame
    {
        void Playthegame();
    }
    public class PlayTheGame : IPlayThegame
    {
        private readonly static Computer1 userComp = Computer1.GetInstance;
        private readonly static Human1 userHuman = Human1.GetInstance;
        private readonly static IGeneralWeapons weapons = GeneralWeapons.GetInstance;
        private static string compUsername = "Comp User";
        private static PlayTheGame instance;
        public void Playthegame()
        {
            Console.WriteLine("Enter your name: ");
            userHuman.UserName = Console.ReadLine().ToUpper();
            userComp.UserName = compUsername.ToUpper();
            userHuman.SetInitialHealtPoint();
            userComp.SetInitialHealtPoint();
            weapons.SetInitialWeapons();

            Console.WriteLine("Lets Start The Game : " + userHuman.UserName + " VS " + userComp.UserName);
            Console.WriteLine();
            while (userComp.HealtPoint > 0 & userHuman.HealtPoint > 0)
            {
                Console.WriteLine(userHuman.UserName + ", PLEASE choose your Weapons? " + weapons.CreateWeaponsList());

                var PlayerWeaponInput = Console.ReadLine();
                var PlayerWeaponType = weapons.GetTypeSelectedWeapons(PlayerWeaponInput);
                if (PlayerWeaponType != null)
                {

                    var getComputerInput = weapons.GetComputerWeapon(PlayerWeaponType);
                    bool isPlayerWin = weapons.isPlayerWeaponWin(PlayerWeaponType, getComputerInput);
                    {
                        Console.WriteLine("Human : (" + weapons.GetWeaponsName(PlayerWeaponType) + ")" + " VS Computer (" + weapons.GetWeaponsName(PlayerWeaponType) + ")");
                        if (isPlayerWin)
                        {

                            userComp.HealtPoint--;
                            Console.WriteLine("Human win " + " Player health :" + userHuman.HealtPoint.ToString() + " vs  Computer Health :" + userComp.HealtPoint.ToString());

                        }
                        else
                        {
                            userHuman.HealtPoint--;
                            Console.WriteLine("Computer win" + " Computer health: " + userComp.HealtPoint.ToString() + " vs  Human Health: " + userHuman.HealtPoint.ToString());

                        }

                    }
                }
                else
                {
                    Console.WriteLine("wrong Input");
                }
            }
            Console.WriteLine("FINISH");
            Console.WriteLine("FINISH");
            Console.WriteLine("FINISH");
            Console.WriteLine("FINISH");

            if (userComp.HealtPoint > userHuman.HealtPoint)
            {
                Console.WriteLine(" SORRY Computer win over Human Player (" + userComp.HealtPoint.ToString() + " VS " + userHuman.HealtPoint.ToString() + ")");
            }
            else
            {
                Console.WriteLine(" CONGRATULATION " + userHuman.UserName + " WIN OVER Computer (" + userHuman.HealtPoint.ToString() + " VS " + userComp.HealtPoint.ToString() + ")");
            }
            Console.ReadLine();
        }
        public static PlayTheGame GetInstance
        {
            get
            {
                if (instance == null) instance = new PlayTheGame();
                return instance;
            }
        }
    }
}
