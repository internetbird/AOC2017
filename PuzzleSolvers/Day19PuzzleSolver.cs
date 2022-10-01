using AOC;
using AOC2017.Logic;
using BirdLib.DataModels;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day19PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day19.txt");

            var scanner = new RoutingDiagramScanner();
            var answer = scanner.ScanLetters(inputLines);

            return answer;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
