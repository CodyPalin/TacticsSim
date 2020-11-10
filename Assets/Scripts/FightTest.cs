using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FightTest
{
    static void Main(string[] args)
    {
        Unit a = new Unit(4, 0, 3, 2, 0, 100);
        Unit b = new Unit(4, 0, 3, 2, 0, 100);
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
                }
                else
                {
                    Console.WriteLine("Attacker wins!");
                }
            }
            exitstring = Console.ReadLine();
        }
    }
}
