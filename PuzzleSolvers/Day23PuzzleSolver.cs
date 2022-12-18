using AOC;
using AOC2017.Logic;
using AOC2017.Parsers;
using BirdLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day23PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] programLines = InputFilesHelper.GetInputFileLines("day23.txt");

            var parser = new DuetComputerInstructionParser();
            var computer = new DuetComputer(parser);
            computer.LoadProgram(programLines);
            computer.ExcuteProgram();


            return computer.GetMulInstunctionInvokeCounter().ToString();
        }

        public string SolvePuzzlePart2()
        {
            // Temporary hardcoded solution
            // Mus take maximum value of b (108100 in my case)
            // and increments it by value of second-to-last instruction
            // up to maximum value of c,
            // and compute the total number of composite values.
            // `1001 - sum(map(pyprimes.isprime, range(108100, 125100, 17)))`

            var count = 0;

            for (int i = 108100; i <= 125100; i+=17)
            {
                if (i.IsPrime())
                {
                    count++;
                }
            }
            return (1001 - count).ToString() ;
        }
    }
}
