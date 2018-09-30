using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    class AI : Player
    {
        public enum Difficulty { EASY, NORMAL, HARD }

        private Difficulty difficulty;

        public Difficulty AIDifficulty
        {
            get
            {
                return difficulty;
            }
        }

        public AI(Difficulty difficulty, TeamSide side) : base(side)
        {
            this.difficulty = difficulty;
        }

        public void tickAI()
        {
            //IA stuff
            spawnUnit(Random.Range(0, 4));
        }
    }
}
