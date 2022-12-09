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
            string[] programLines = InputFilesHelper.GetInputFileLines("day23.test.txt");

            var parser = new DuetComputerInstructionParser();
            var computer = new CoprocessorComputer(parser);

            computer.LoadProgram(programLines);


            computer.OnAfterInstructionExecuted += (sender, args) =>
            {
                if (computer.GetResultRegisterValue() != 0)
                {
                    Console.WriteLine("Register h equals :" + computer.GetResultRegisterValue());
                }
            };

            computer.ExcuteProgram();

            return computer.GetResultRegisterValue().ToString();
        }
    }
}
