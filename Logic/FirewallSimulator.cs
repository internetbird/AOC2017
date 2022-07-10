using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class FirewallSimulator
    {
        private List<FirewallLayer> _layers;
        private FirewallState _state;

        public FirewallSimulator(List<FirewallLayer> layers)
        {
            _layers = layers;
        }


        /// <summary>
        /// Runs the firewall simulation start to end
        /// </summary>
        /// <returns>The total serverity</returns>
        public int RunSimulation()
        {

            int totalSeverity = 0;


            return totalSeverity;
        }
    }
}
