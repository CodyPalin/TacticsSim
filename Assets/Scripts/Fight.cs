using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Fight
{
    public int terrain = 0; 
    public Fight(int terrain = 0) //will add other things here, terrain and elevation and such will have an effect on the fight.
    {
        this.terrain = terrain;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Attacker"></param>
    /// <param name="Defender"></param>
    /// <returns> true if fight is over, false otherwise</returns>
    public bool Tick (ref Unit Attacker, ref Unit Defender)
    {
        int AttackerDamage = (int)(Defender.Defense * (Defender.StrengthPercentage()*1/Attacker.StrengthPercentage()));
        int DefenderDamage = (int)(Attacker.Attack * (Attacker.StrengthPercentage() * 1 / Defender.StrengthPercentage()));
        Attacker.Damage(AttackerDamage);
        Defender.Damage(DefenderDamage);
        if (Attacker.CurrentStrength == 0 || Defender.CurrentStrength == 0)
            return true;
        return false;
    }
}
