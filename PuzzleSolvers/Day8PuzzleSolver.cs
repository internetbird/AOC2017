using AOC;
using AOC2017.Logic;
using AOC2017.Models;
using AOC2017.Parsers;
using BirdLib.AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day8PuzzleSolver : IAsyncPuzzleSolver
    {
        public async Task<string> SolvePuzzlePart1()
        {
           var cpuCommands = ParseInputFileCommands();

            var cpuSimulator = new CPUSimulator();
            await cpuSimulator.RunCommands(cpuCommands);
            return cpuSimulator.GetMaxRegisterValue().ToString(); ;

        }

        public Task<string> SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }


        private List<CPUCommand> ParseInputFileCommands()
        {
            var commands = new List<CPUCommand>();

            string[] inputFileLines = InputFilesHelper.GetInputFileLines("day8.txt");
            for (int i = 0; i < inputFileLines.Length; i++)
            {
                CPUCommand command = CPUCommandParser.ParseCommand(inputFileLines[i]);
                commands.Add(command);
            }

            return commands;

        }
    }
}
