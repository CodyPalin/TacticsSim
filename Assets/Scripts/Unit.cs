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
    public int Speed { get; private set; }
    public int Range { get; private set; }
    public int MaxStrength { get; private set; }
    public int CurrentStrength { get; private set; }
    public Unit(int attack, int rangedAttack, int defense, int speed, int range, int strength)
    {
        Attack = attack;
        RangedAttack = rangedAttack;
        Defense = defense;
        Speed = speed;
        Range = range;
        MaxStrength = strength;
        CurrentStrength = strength;
    }
    public bool Damage(int damageAmount)
    {
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
