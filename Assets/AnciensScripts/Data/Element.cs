using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Data
{
    //Used to manage element weakness and powerful
    public class Element
    {
        public static readonly Element FIRE = new Element(0, WATER, AIR);
        public static readonly Element WATER = new Element(1, GROUND, FIRE);
        public static readonly Element GROUND = new Element(2, AIR, WATER);
        public static readonly Element AIR = new Element(3, GROUND, FIRE);

        private readonly Element powerful;
        private readonly Element weakness;

        private readonly int elementId;
        public int ElementId
        {
            get
            {
                return elementId;
            }
        }

        public Element Weakness
        {
            get
            {
                return weakness;
            }
        }
        public Element Powerful
        {
            get
            {
                return powerful;
            }
        }

        private Element(int elementId, Element weakness, Element powerful)
        {
            this.elementId = elementId;
            this.weakness = weakness;
            this.powerful = powerful;
        }

        public Boolean isPowerfulAgainst(Element other)
        {
            return powerful == other;
        }

        public Boolean isWeakAgainst(Element other)
        {
            return weakness == other;
        }

        public Boolean isNotAffectedAgainst(Element other)
        {
            return !isPowerfulAgainst(other) && !isWeakAgainst(other);
        }
    }
}
