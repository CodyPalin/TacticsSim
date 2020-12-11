using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FightTest
{
    static void Main(string[] args)
    {
        Unit a = new Unit(20, 0, 8, 25, 6, 0, 60);
        Unit b = new Unit(6, 15, 6, 8, 4, 10, 100);
        //Unit infantry = new Unit(12, 0, 10, 20, 3, 0, 100);
        Fight fight1 = new Fight();
        string exitstring = "";
        while (exitstring!="exit" )
        {
            bool fightover = fight1.Tick(ref a, ref b);
            Console.WriteLine("\nAttacker:"+a.ToString());
            Console.WriteLine("\nDefender:" + b.ToString());
            if(!fightover)
                Console.WriteLine("Press enter to continue, type exit to exit...");
            else
            {
                if (a.IsDestroyed())
                {
                    Console.WriteLine("Defender wins!");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Attacker wins!");
                    Console.ReadLine();
                    return;
                }
            }
            exitstring = Console.ReadLine();
        }
    }
}
