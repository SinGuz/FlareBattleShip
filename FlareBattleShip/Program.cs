using System;
using FlareBattleShip.Util;
using FlareBattleShip.BLData;

namespace FlareBattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            string rl = "";
            string[] arr;
            int i;
            int j;
            
            BattleShipBoard bsb = new BattleShipBoard(10);
            bsb.DrawShip(6);
            bsb.DrawShip(2);
            bsb.DrawShip(1);

            BattleShipStateManager bssm = new BattleShipStateManager(bsb);

            Console.WriteLine("you can type EXIT at any time to continue");
            while (true)
            {
                Console.Write("Please enter location to attack (two integers with space in between): ");
                rl = Console.ReadLine();

                if (rl.ToLower() == "exit")
                    break;

                try
                {
                    arr = rl.Trim().Split(' ');
                    i = Int16.Parse(arr[0]);
                    j = Int16.Parse(arr[1]);
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                Enums.AttackResult ar = bssm.ReceiveAttack(i, j);
                Console.WriteLine(Helper.GetStringFromAttackEnum(ar));

                if (ar == Enums.AttackResult.AllSunk)
                {
                    Console.WriteLine("CONGRATULATIONS!!!! GAME ENDS NOW");
                    break;
                }

            }

        }


    }
}
