using AOC2017.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2017.PuzzleSolvers
{
    public class Day5PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day5.txt");

            int[] instructions = inputLines.Select(line => int.Parse(line)).ToArray();


            return string.Empty;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
