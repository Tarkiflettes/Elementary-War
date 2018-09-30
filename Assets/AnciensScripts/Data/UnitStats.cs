using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Data
{
    //Store unitStats
    public class UnitStats
    {
        private float hp;
        private float attack;
        private float defense;
        private float magicAttack;
        private float magicDefense;

        public float HP
        {
            get
            {
                return hp;
            }
        }

        public float Attack
        {
            get
            {
                return attack;
            }
        }

        public float Defense
        {
            get
            {
                return defense;
            }
        }

        public float MagicAttack
        {
            get
            {
                return magicAttack;
            }
        }

        public float MagicDefense
        {
            get
            {
                return magicDefense;
            }
        }

        public UnitStats(float hp, float att, float def, float magicAtt, float magicDef)
        {
            this.hp = hp;
            this.attack = att;
            this.defense = def;
            this.magicAttack = magicAtt;
            this.magicDefense = magicDef;
        }

        public static UnitStats operator*(UnitStats stats, float coef)
        {
            return new UnitStats(stats.hp * coef, stats.attack * coef, stats.defense * coef, stats.magicAttack * coef, stats.magicDefense * coef);
        }

        public int getMoneyForStats()
        {
            return 0;//TODO calculer montant
        }
    }
}
