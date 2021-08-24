using AOC2017.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2017.PuzzleSolvers
{
    public class Day3PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var calculator = new SpiralMemoryCalculator();

            int index =  calculator.GetSpiralIndexForLocation(22);

            return index.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
