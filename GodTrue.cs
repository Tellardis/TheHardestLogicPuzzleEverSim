using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHardestLogicPuzzleEverSim
{
    public class GodTrue : God
    {
        public bool Reply(Question q)
        {
            var fisrtStep = q.Subject.ToString() == q.GodType;
            var secondStep = q.GodAnswer == fisrtStep;
            return secondStep;
        }
        public override string ToString() => "GodTrue";
    }
}
