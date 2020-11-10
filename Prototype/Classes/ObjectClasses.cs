using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace Prototype.Objects
{
    public enum Type
    {
        //Offinse
        Pistol,

        Rifle,
        Sword,
        Dagger,
        Lance,
        Polearm,

        //Defensive
        Shield,

        Legs,
        Chest,
        Head,
        Arms,
        Hands,
        Feet
    }

    public enum Rarity
    {
        //Normal
        Junk,//Trash

        Worn,//Common
        Glitchy,//Rare
        Pristine,//Epic
        Master_Craft,//Legendary (from unique sorces)

        //Special Types
        Corrupted,//Special stats that may increace one stat but take away from another

        Infected,//Very powerful but slowly destroys itself
        BSOD,//Exprimental gear that if used with out proper routines will cause instant KO
             //BSOD limit is 1 normally
    }

    public enum DamageType
    {
        Physical,
        Overload,
        Burn,
        Freeze
    }

    public enum Effect
    {
        Heal,
        Damage,
        Buff,
        Special //May not be used
    }
    public enum Buff
    {
        STR, 
        SPD, 
        AGI, 
        LVL, 
        EXP,
        MHP
    }

    public class Character
    {
        //Member variables (mostly stats)

        private int health, strength, speed, agility, level, exp, maxHealth;
        private string name = string.Empty;
        public bool isDead = false;
        public Dictionary<string, Equipment> EquimentSlots = new Dictionary<string, Equipment>();

        #region Contructor(s)

        public Character()
        {
            EquimentSlots.Add("Head", new Equipment());
            EquimentSlots.Add("Chest", new Equipment());
            EquimentSlots.Add("Arms", new Equipment());
            EquimentSlots.Add("Hands", new Equipment());
            EquimentSlots.Add("Legs", new Equipment());
            EquimentSlots.Add("Feet", new Equipment());
            EquimentSlots.Add("Main_Hand", new Equipment());
            EquimentSlots.Add("Off_Hand", new Equipment());

            //Setting type to for input checks
            EquimentSlots["Head"].setType(Type.Head);
            EquimentSlots["Chest"].setType(Type.Chest);
            EquimentSlots["Arms"].setType(Type.Arms);
            EquimentSlots["Hands"].setType(Type.Hands);
            EquimentSlots["Legs"].setType(Type.Legs);
            EquimentSlots["Feet"].setType(Type.Feet);
        }

        #endregion Contructor(s)

        #region Accessors
        public int GetHealth()
        {
            return health;
        }
        public int GetStrength()
        {
            return strength;
        }
        public int GetSpeed()
        {
            return speed;
        }
        public int GetAgility()
        {
            return agility;
        }
        public int GetLevel()
        {
            return level;
        }
        public int GetEXP()
        {
            return exp;
        }
        public int GetMaxHealth()
        {
            return maxHealth;
        }
        #endregion

        #region Mutators
        public void SetHealth(int hp)
        {
            health = hp;
        }
        public void SetStrength(int update)
        {
            strength = update;
        }
        public void SetSpeed(int update)
        {
            speed = update;
        }
        public void SetAgility(int update)
        {
            agility = update;
        }
        public void SetLevel(int update)
        {
            level = update;
        }
        public void SetEXP(int update)
        {
            exp = update;
        }
        public void SetMaxHealth(int update)
        {
            maxHealth = update;
        }
        #endregion

    }

    public class Equipment
    {
        #region Constructors

        public Equipment(int dur, int att, int def, int speed, int agil, int strength, bool magic,
            string name, Type gearType, Rarity gearRarity, DamageType damage)
        {
            durability = dur; attack = att; defenseBonus = def; speedBonus = speed;
            agilityBonus = agil; strenghtBonus = strength; isMagic = magic; Name = name;
            type = gearType; rarity = gearRarity; damageType = damage;
        }

        public Equipment()
        {
        }

        #endregion Constructors

        //Member varriables mostly stats

        private int durability, attack, defenseBonus, speedBonus, agilityBonus, strenghtBonus;
        private bool isMagic;
        private string Name = string.Empty;
        private Type type; private Rarity rarity; private DamageType damageType;

        #region Accessors

        public int getDurablity()
        {
            return durability;
        }

        public int getAttack()
        {
            return attack;
        }

        public int getDefBonus()
        {
            return defenseBonus;
        }

        public int getSpeedBonus()
        {
            return speedBonus;
        }

        public int getAgiityBonus()
        {
            return agilityBonus;
        }

        public int getStrengthBonus()
        {
            return strenghtBonus;
        }

        public bool getIsMagic()
        {
            return isMagic;
        }

        public string getName()
        {
            return Name;
        }

        public Type GetGearType()
        {
            return type;
        }

        public Rarity getGearRarity()
        {
            return rarity;
        }

        public DamageType getDmagae() //Damage type
        {
            return damageType;
        }

        

        #endregion Accessors

        #region Mutators

        public void setDurability(int newDur)
        {
            durability = newDur;
        }

        public void setAttack(int newAttack)
        {
            attack = newAttack;
        }

        public void setDefBonus(int newDefBonus)
        {
            defenseBonus = newDefBonus;
        }

        public void setSpeedBonus(int newSpeedBonus)
        {
            speedBonus = newSpeedBonus;
        }

        public void setAgilityBonus(int newAgility)
        {
            agilityBonus = newAgility;
        }

        public void setStrengthBonus(int newStrenght)
        {
            strenghtBonus = newStrenght;
        }

        public void setIsMagic(bool isitmagicorwhat)
        {
            isMagic = isitmagicorwhat;
        }

        public void setName(string newName)
        {
            Name = newName;
        }

        public void setType(Type newtype)
        {
            type = newtype;
        }

        public void setRarity(Rarity newrarity)
        {
            rarity = newrarity;
        }

        public void setDamageType(DamageType damagetype)
        {
            damageType = damagetype;
        }

        #endregion Mutators
    }

    public class Item
    {
        #region Constructors

        private Item(Effect type, int ammount, string name)
        {
            effect = type;
            points = ammount;
            Name = name;
        }

        private Item(string name)
        {
            Name = name;
        }

        private Item()
        {
        }

        #endregion Constructors

        private Effect effect;
        private Buff buff;
        //Points of type
        private int points = 0;
        //set to 0 for indefinite
        private int Duration;
        public string Name;

        #region Accessors

        public Effect GetEffect()
        {
            return effect;
        }
        public Buff GetBuff()
        {
            return buff;
        }

        public int GetPoints()
        {
            return points;
        }
        public int GetDuration()
        {
            return Duration;
        }

        #endregion Accessors

        #region Mutators

        public void SetEffect(Effect new_effect)
        {
            effect = new_effect;
        }
        public void SetBuff(Buff new_buff)
        {
            buff = new_buff;
        }

        public void SetPoints(int ammount)
        {
            points = ammount;
        }
        public void SetDuration(int update)
        {
            Duration = update;
        }

        #endregion Mutators

        public void UseItem(Character target, Item item)
        {
            Effect effect = item.GetEffect();
            switch (effect)
            {
                case Effect.Heal:
                    if(target.GetHealth() + item.GetPoints()>= target.GetMaxHealth())
                    {
                        target.SetHealth(target.GetMaxHealth());
                    }
                    else
                    {
                        target.SetHealth(target.GetHealth() + item.GetPoints());
                    }
                    break;
                case Effect.Damage:
                    if(target.GetHealth() - item.GetPoints() <= 0)
                    {
                        target.isDead = true;
                    }
                    else
                    {
                        target.SetHealth(target.GetHealth() - item.GetPoints());
                    }
                    break;
                case Effect.Buff:
                    switch(item.GetBuff())
                    {
                        case Buff.AGI:
                            break;
                        case Buff.EXP:
                            break;
                        case Buff.LVL:
                            break;
                        case Buff.MHP:
                            break;
                        case Buff.SPD:
                            break;
                        case Buff.STR:
                            break;
                        default:
                            Console.WriteLine("Something broke ObjectClasses.cs Line 416-ish", Color.Red);
                            break;
                    }
                    break;
                case Effect.Special:
                    //apply special
                    break;
                default:
                    Console.WriteLine("Something broke. ObjectClasses.cs Line 316-ish", Color.Red);
                    break;
            }
                
        }

    }
}