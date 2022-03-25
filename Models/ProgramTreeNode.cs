using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public record ProgramTreeNode
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<string> SubProgramsNames { get; set; }
    }
}
