using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHardestLogicPuzzleEverSim
{
    public class GodRandom : God
    {
        public bool Reply(Question q)
        {
            return new Random().Next(0, 1) == 1;
        }
        public override string ToString() => "GodRandom";
    }
}
