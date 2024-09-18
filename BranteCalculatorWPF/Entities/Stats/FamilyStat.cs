using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculator.Entities.Stats
{
    public class FamilyStat : Stat
    {
        public FamilyStat(string name, int value) : base(name, value, 0, 10)
        {
        }
    }
}
