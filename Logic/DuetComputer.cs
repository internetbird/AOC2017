using AOC2017.Models;
using AOC2017.Parsers;
using BirdLib.AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class DuetComputer : ComputerSimulator<DuetComputerInstruction, DuetComputerInstuctionType>
    {
        public DuetComputer(DuetComputerInstructionParser parser) : base(parser)
        {
        }

        protected override void ExecuteInsturction(DuetComputerInstruction instructionToExecute)
        {
            throw new NotImplementedException();
        }
    }
}
