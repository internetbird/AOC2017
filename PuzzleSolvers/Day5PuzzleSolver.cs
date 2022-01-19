using AOC;
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

            int numOfSteps = 0;
            int currPosition = 0;

            while(currPosition < instructions.Length)
            {
                int jumpValue = instructions[currPosition];

                instructions[currPosition]++;
                currPosition += jumpValue;

                numOfSteps++;
            }

            return numOfSteps.ToString();
        }

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day5.txt");

            int[] instructions = inputLines.Select(line => int.Parse(line)).ToArray();

            int numOfSteps = 0;
            int currPosition = 0;

            while (currPosition < instructions.Length)
            {
                int jumpValue = instructions[currPosition];

                if(jumpValue >= 3)
                {
                    instructions[currPosition]--;
                } else
                {
                    instructions[currPosition]++;
                }

                currPosition += jumpValue;

                numOfSteps++;
            }

            return numOfSteps.ToString();
        }
    }
}
