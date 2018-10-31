using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Data
{
    //Team's base
    public class Castle
    {
        private int hp = 1500;//Default HP value

        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }
    }
}
