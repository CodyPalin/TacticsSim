using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
public class Unit
{
    public int Attack { get; private set; }
    public int RangedAttack { get; private set; }
    public int Defense { get; private set; }
    public int Armor { get; private set; }
    public int Speed { get; private set; }
    public int Range { get; private set; }
    public int MaxStrength { get; private set; }
    public int CurrentStrength { get; private set; }
    Random rand;
    public Unit(int attack, int rangedAttack, int defense,int armor, int speed, int range, int strength)
    {
        Attack = attack;
        RangedAttack = rangedAttack;
        Defense = defense;
        Speed = speed;
        Range = range;
        MaxStrength = strength;
        CurrentStrength = strength;
        Armor = armor;
        rand = new Random();
    }
    public bool Damage(int damageValue)
    {
        int ArmorEffectivenessVariant = rand.Next(-10, 10);
        int ArmorEffect = Armor + ArmorEffectivenessVariant;
        if (ArmorEffect < 0) ArmorEffect = 0;
        int damageAmount = (int)(damageValue-((double)ArmorEffect/100)*damageValue);
        if (damageAmount <= 0)
            return true;
        if (CurrentStrength <= damageAmount)
        {
            CurrentStrength = 0;
            return true;
        }
        else
        {
            CurrentStrength -= damageAmount;
            return false;
        }
    }
    public override string ToString()
    {
        string retval = "";
        retval += "\nAttack:" + Attack;
        retval += "\nRangedAttack:" + RangedAttack;
        retval += "\nDefense:" + Defense;
        retval += "\nArmor:" + Armor;
        retval += "\nSpeed:" + Speed;
        retval += "\nRange:" + Range;
        retval += "\nStrength:" + CurrentStrength+"/"+MaxStrength;
        return retval;
    }
    public double StrengthPercentage()
    {
        double unrounded = ((double)CurrentStrength / MaxStrength);
        return (Math.Round(unrounded, 2));
    }
    public bool IsDestroyed()
    {
        if (CurrentStrength == 0)
            return true;
        return false;
    }
}
