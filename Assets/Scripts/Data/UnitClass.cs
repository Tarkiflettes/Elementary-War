using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Data
{
    //Contains classes, handle evolution with levels
    public class UnitClass
    {
        public static readonly UnitClass ARCHER = new UnitClass(0, new UnitStats(23, 17, 6 , 5, 6));
        public static readonly UnitClass MAGE = new UnitClass(1, new UnitStats(23, 5, 8, 30, 7));
        public static readonly UnitClass TANK = new UnitClass(2, new UnitStats(45, 13, 12, 5, 23));
        public static readonly UnitClass SWORDMAN = new UnitClass(3, new UnitStats(35, 20, 11, 5, 20));

        private readonly UnitStats defaultStats;
        private readonly int classId;
        public int ClassId
        {
            get
            {
                return classId;
            }
        }

        private UnitClass(int classId, UnitStats defaultStats)
        {
            this.classId = classId;
            this.defaultStats = defaultStats;
        }

        public UnitStats getStatsForLevel(int level)
        {
            UnitStats stats = defaultStats;
            for(int i = 1; i < level;i++)
            {
                stats *= 1.15F;
            }

            return stats;
        }
    }
}
