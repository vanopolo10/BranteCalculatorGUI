using BranteCalculator.Entities.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculatorWPF.Entities.Stats
{
    internal class ProvinceStat : Stat
    {
        public ProvinceStat(string name, int value) : base(name, value, 0, 10)
        {
        }
    }
}
