using AOC2017.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class CoprocessorComputer : DuetComputer
    {
        public CoprocessorComputer(DuetComputerInstructionParser parser) : base(parser)
        {
            SetRegisterValue("a", 1);
        }


        public long GetResultRegisterValue()
        {
            return GetRegisterValue("h");
        }
    }
}
