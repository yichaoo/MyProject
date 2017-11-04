using System;
using Autofac;

namespace AutoFacDemo
{
    class Program
    {
    
        static void Main(string[] args)
        {
            //var weapon1 = new Fireball();
            //var weapon2 = new Sword();
            //var enemy = new Orca();
            //var player1 = new Archmage(weapon1, enemy);            
            //var player2 = new Knight(weapon2, enemy);

            //player1.Attack();
            //player2.Attack();

            AutofacExt.InitAutofac();
            IPlayer player = AutofacExt.GetFromFac<IPlayer>();
            player.Attack();

            Console.ReadLine();
        }
      
    }


}
