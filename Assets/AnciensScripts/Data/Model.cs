using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Data
{
    //Unit model to define stats for each of them
    public class Model
    {
        private UnitClass modelClass;
        private UnitStats stats;
        private Element modelElement;
        private int elementLevel;
        private Sprite unitSprite;
        public Sprite UnitSprite
        {
            get
            {
                return unitSprite;
            }
        }

        public UnitClass ModelClass
        {
            get
            {
                return modelClass;
            }
        }

        public UnitStats Stats
        {
            get
            {
                return stats;
            }
        }

        public Element ModelElement
        {
            get
            {
                return modelElement;
            }
        }

        public int ElementLevel
        {
            get
            {
                return elementLevel;
            }
        }

        public Model(UnitClass modelClass, int classLevel, Element modelElement, int elementLevel)
        {
            this.modelClass = modelClass;
            this.stats = modelClass.getStatsForLevel(classLevel);
            this.modelElement = modelElement;
            this.elementLevel = elementLevel;
            this.unitSprite = SpriteList.getUnitSprite(this);
        }
    }
}
