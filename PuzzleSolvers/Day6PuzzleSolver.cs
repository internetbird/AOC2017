using AOC;
using AOC2017.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2017.PuzzleSolvers
{
    public class Day6PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string inputConfiguration = InputFilesHelper.GetInputFileText("day6.txt");

           List<int> initialConfiguration = inputConfiguration.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            var simulator = new MemoryBlocksSimulator(initialConfiguration);

            int numOfRedistrubutions = simulator.Run();

            return numOfRedistrubutions.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
