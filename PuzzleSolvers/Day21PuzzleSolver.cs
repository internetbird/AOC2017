using AOC;
using AOC2017.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day21PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] ruleLines = InputFilesHelper.GetInputFileLines("day21.txt");

            var grid = new FractalGrid(ruleLines);

            grid.RunInterations(5);

            return grid.GetNumOfOnPixels().ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
