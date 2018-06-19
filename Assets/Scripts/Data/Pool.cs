using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Data
{
    //Model pool
    public class Pool
    {
        private Model[] poolModels;
        public Model[] PoolModels
        {
            get
            {
                return poolModels;
            }
        }

        public Pool(Model[] poolModels)
        {
            this.poolModels = poolModels;
        }
    }
}
