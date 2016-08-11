using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lol
{
    class Champion
    {
        // Basic Info
        public string Name { get; set; }
        public string Title { get; set;  }
        public int Id { get; set; }
        //Stats

        // Do i want to change this to be more readable / less dumb?  maybe
        public double Hp { get; set; }
        public double HpPerLevel { get; set; }
        public double Mp { get; set; }
        public double MpPerLevel { get; set; }
        public double Movespeed { get; set; }
        public double Armor { get; set; }
        public double ArmorPerLevel { get; set; }
        public double SpellBlock { get; set; }
        public double SpellBlockPerLevel { get; set; }
        public double AttackRange { get; set; }
        public double HpRegen { get; set; }
        public double HpRegenPerLevel { get; set; }
        public double MpRegen { get; set; }
        public double MpRegenPerLevel { get; set; }
        public double Crit { get; set; }
        public double CritPerLevel { get; set; }
        public double AttackDamage { get; set; }
        public double AttackDamagePerLevel { get; set; }
        public double AttackSpeedOffset { get; set; }
        public double AttackSpeedPerLevel { get; set; }



        public Champion()
        {
            Name = "none given";
            Title = "not given";
            Id = 0;

        }

        public Champion(string _name, string _title, int _id, double hp
                     , double hpperlevel, double mp, double mpperlevel, double movespeed, double armor, double armorperlevel
                     , double spellblock, double spellblockperlevel, double attackrange, double hpregen, double hpregenperlevel, double mpregen, double mpregenperlevel, double crit
                     , double critperlevel, double attackdamage, double attackdamageperlevel, double attackspeedoffset, double attackspeedperlevel)
        {
            Name = _name;
            Title = _title;
            Id = _id;
            Hp = hp;
            HpPerLevel = hpperlevel;
            Mp = mp;
            MpPerLevel = mpperlevel;
            Movespeed = movespeed;
            Armor = armor;
            ArmorPerLevel = armorperlevel;
            SpellBlock = spellblock;
            SpellBlockPerLevel = spellblockperlevel;
            AttackRange = attackrange;
            HpRegen = hpregen;
            HpRegenPerLevel = hpregenperlevel;
            MpRegen = mpregen;
            MpRegenPerLevel =mpregenperlevel;
            Crit = crit;
            CritPerLevel = critperlevel;
            AttackDamage = attackdamage;
            AttackDamagePerLevel = attackdamageperlevel;
            AttackSpeedOffset = attackspeedoffset;
            AttackSpeedPerLevel = attackspeedperlevel; 

        }

        public string ReturnInfoToString()
        {
            string returnString = "Champion Name: " + Name + "\nChampion Title: " + Title + "\nChampion id: " + Id + "\nBase Hp: " + Hp + "\nHp Per Level: " + HpPerLevel
                + "\nMp: " + Mp + "\nMp Per Level: " + MpPerLevel + "\nBase Movespeed: " + Movespeed + "\nArmor: " + Armor + "\nArmor Per Level: " + ArmorPerLevel
                + "\nMagic Resist: " + SpellBlock + "\nMagic Resist Per Level: " + SpellBlockPerLevel + "\nAttack Range: " + AttackRange + "\nHp Regen: " 
                + HpRegen + "\nHp Regen Per Level: " + HpRegenPerLevel + " \nMp Regen: " + MpRegen + "\nMp Regen Per Level: " + MpRegenPerLevel + "\nAttack Damage: "
                + AttackDamage + "\nAttack Damage Per Level: " + AttackDamagePerLevel + "\nAttack Speed Per Level: " + AttackSpeedPerLevel;
            return returnString;
        }
    }
}
