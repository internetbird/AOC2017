using AOC;
using AOC2017.Logic;
using AOC2017.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day18PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] programLines = InputFilesHelper.GetInputFileLines("day18.txt");

            var parser = new DuetComputerInstructionParser();
            var computer = new DuetComputer(parser);
            computer.LoadProgram(programLines);
            computer.ExcuteProgram();

            return string.Empty;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
