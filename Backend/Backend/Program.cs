
using Backend.User.Comp;
using Backend.User.Human;
using Backend.Weaponses;
using System;

namespace Backend
{
    class Program
    {
        private readonly static IPlayThegame play = PlayTheGame.GetInstance;
        static void Main(string[] args)
        {

            play.Playthegame();
        }



    }
}

/*
 1.Enter name
 2. choose QWE
 Q W E == > enum 3 health Point

    Rock ==> Scrisss=> 
    papaer==> Rock
    Scissor ++ >papaer

     compute  win... compute --
     dispya result
     Compuet Won

    Rmaining Helath
    3



     */