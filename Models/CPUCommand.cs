using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public class CPUCommand
    {
        public string RegisterToUpdate { get; set; }
        public CPUCommandType CommandType { get; set; }
        public int CommandOperand { get; set; }
        public string Condition { get; set; }
    }
}
