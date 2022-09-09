using BirdLib.AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public class DuetComputerInstruction : IComputerInstruction<DuetComputerInstuctionType>
    {
        public DuetComputerInstuctionType Type { get; set; }
        public string Operand1 { get; set; }
        public string Operand2 { get; set; }
    }
}
