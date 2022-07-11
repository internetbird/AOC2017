using AOC;
using AOC2017.Logic;
using AOC2017.Models;
using AOC2017.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day13PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day13.txt");

            List<FirewallLayer> firewallLayers = inputLines.Select(FirewallLayerParser.ParseLine).ToList();

            var simulator = new FirewallSimulator(firewallLayers);

            int serverity = simulator.Run();

            return serverity.ToString();
        }

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day13.txt");

            List<FirewallLayer> firewallLayers = inputLines.Select(FirewallLayerParser.ParseLine).ToList();

            var simulator = new FirewallSimulator(firewallLayers);
            int delay = 0;
            bool success = simulator.RunPassThrough(delay);

            while(!success)
            {
                delay++;
                success = simulator.RunPassThrough(delay);
            }
            
            return delay.ToString();
        }
    }
}
