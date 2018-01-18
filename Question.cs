using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHardestLogicPuzzleEverSim
{
    public class Question
    {
        public God Subject { get; set; }
        public string GodType { get; set; }
        public bool GodAnswer { get; set; }
        public override string ToString()
        {
            return $"Ты оветил бы {Program.Dict[GodAnswer]}, если бог {Program.Gods.First(x => x.Value.ToString() == Subject.ToString()).Key} это {GodType}";
        }

    }
}
