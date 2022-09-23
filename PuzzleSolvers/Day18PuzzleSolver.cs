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

            return computer.GetFirstRecoveredFrequency().ToString();
        }

        public string SolvePuzzlePart2()
        {
            string[] programLines = InputFilesHelper.GetInputFileLines("day18.txt");

            var parser = new Duet2ComputerInstructionParser();
            var computer0 = new Duet2Computer(parser, 0);
            var computer1 = new Duet2Computer(parser, 1);



            return computer1.GetValuesSentCounter().ToString();
        }
    }
}
