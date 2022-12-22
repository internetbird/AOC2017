using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public class TuringMachineConfiguration
    {
        public string InitialState { get; set; }
        public Dictionary<string, TuringMachineRule> Rules { get; set; }

        public TuringMachineConfiguration()
        {
            Rules = new Dictionary<string, TuringMachineRule>();
        }

        public void AddRule(string ruleState, TuringMachineRule rule)
        {
            Rules.Add(ruleState, rule);
        }
    }
}
