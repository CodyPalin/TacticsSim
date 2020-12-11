using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Fight
{
    public double AttackModifier = 0;
    public double DefenseModifier = 0;
    public double Attack;
    public double Defense;
    public Fight(double attackmod = 1, double defensemod = 1) //will add other things here, terrain and elevation and such will have an effect on the fight.
    {
        AttackModifier = attackmod;
        DefenseModifier = defensemod;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Attacker"></param>
    /// <param name="Defender"></param>
    /// <returns> true if fight is over, false otherwise</returns>
    public bool Tick (ref Unit Attacker, ref Unit Defender)
    {
        double attackEffectiveness = (100-(Math.Pow((100-Attacker.StrengthPercentage()*100)/46.45, 6)))/100;
        double defenseEffectiveness = (100 - (Math.Pow((100 - Defender.StrengthPercentage() * 100) / 46.45, 6))) / 100;
        Attack = CalcAttack(Attacker.Attack,attackEffectiveness);
        Defense = CalcDefense(Attacker.Defense, defenseEffectiveness);
        int DefenderDamageDealt = (int)(Defense*(100.0/(100+Attack)));
        int AttackerDamageDealt = (int)(Attack*(100.0/(100+Defense)));
        Attacker.Damage(DefenderDamageDealt);
        Defender.Damage(AttackerDamageDealt);
        if (Attacker.CurrentStrength == 0 || Defender.CurrentStrength == 0)
            return true;
        return false;
    }

    private double CalcAttack(int attack,double effectiveness)
    {
        return AttackModifier * attack * effectiveness;
    }
    private double CalcDefense(int defense, double effectiveness)
    {
        return DefenseModifier * defense * effectiveness;
    }
}
