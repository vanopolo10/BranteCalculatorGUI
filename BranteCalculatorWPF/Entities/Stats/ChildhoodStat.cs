using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculator.Entities.Stats
{
    public class ChildhoodStat : Stat
    {
        private Stat[] _youthStats;

        public ChildhoodStat(string name, params Stat[] youthStats) : base(name, 0, 0, 10)
        {
            _youthStats = youthStats;
        }

        public override void Add(int a)
        {
            Value += a;
            for (int i = 0; i < _youthStats.Length; i++) 
            {
                _youthStats[i] += a;
            }
        }
    }
}
