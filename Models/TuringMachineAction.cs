using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public class TuringMachineAction
    {
        public bool WriteValue { get; set; }
        public int HeadMove { get; set; }
        public string TransitionToState { get; set; }
    }
}
