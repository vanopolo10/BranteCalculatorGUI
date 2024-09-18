using BranteCalculator.Entities.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculator.Entities.Characters
{
    public class Relations : Stat
    {
        public Relations(int value) : base("STAT_CHARACTERS_RELATIONS", value, -5, 5)
        {
        }
    }
}
