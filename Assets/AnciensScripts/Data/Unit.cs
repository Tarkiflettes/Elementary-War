using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Data
{
    //Unit is a soldier.
    public class Unit
    {
        private Player player;
        private Model unitModel;
        private float hp;

        public Player Player
        {
            get
            {
                return player;
            }
        }

        public Model UnitModel
        {
            get
            {
                return unitModel;
            }
        }

        public float HP
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

        public Unit(Player player, Model model)
        {
            this.player = player;
            this.unitModel = model;
            this.hp = model.Stats.HP;

        }

        public bool isEnemyWith(Unit unit)
        {
            return player != unit.player;
        }
    }
}
