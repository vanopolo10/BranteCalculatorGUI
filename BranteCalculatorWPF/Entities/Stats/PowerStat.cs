using BranteCalculator.Entities.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculatorWPF.Entities.Stats
{
    public class PowerStat : Stat
    {
        public PowerStat(string name) : base(name, -4, -5, 5)
        {
        }
    }
}
