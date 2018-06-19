using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Data
{
    //Handle player data
    public class Player
    {
        public enum TeamSide{LEFT, RIGHT};

        private TeamSide side;
        private Pool pool;
        private int money;
        private int classPoint;
        private int elementPoint;
        private List<Castle> castleList = new List<Castle>();
        public List<Castle> CastleList
        {
            get
            {
                return castleList;
            }
        }

        private List<Unit> unitList = new List<Unit>();

        public TeamSide Side
        {
            get
            {
                return side;
            }
        }

        public Pool Pool
        {
            get
            {
                return pool;
            }
            set
            {
                pool = value;
            }
        }

        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }

        public int ClassPoint
        {
            get
            {
                return classPoint;
            }
            set
            {
                classPoint = value;
            }
        }

        public int ElementPoint
        {
            get
            {
                return elementPoint;
            }
            set
            {
                elementPoint = value;
            }
        }

        public List<Unit> UnitList
        {
            get
            {
                return unitList;
            }
        }

        public Player(TeamSide side)
        {
            this.side = side;
        }
        
        public void spawnUnit(int id)
        {
            GameObject unit = GameController.Instantiate(GameController.instance.unityUnit);
            unit.tag += "";
            unit.transform.position = new Vector3(side == TeamSide.LEFT ? -15 : 15, -2, 0);
            UnityUnit uunit = unit.GetComponent<UnityUnit>();
            uunit.Unit = new Unit(this, pool.PoolModels[id]);

            UnitList.Add(uunit.Unit);

        }
    }
}
