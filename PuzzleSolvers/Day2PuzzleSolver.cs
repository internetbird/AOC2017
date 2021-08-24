using AOC2017.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2017.PuzzleSolvers
{
    public class Day2PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day2.txt");
            int checksum = 0;

            foreach (string line in inputLines)
            {
                int[] nums = InputFilesHelper.ParseNumbersLine(line);
                int maxValue = nums.Max();
                int minValue = nums.Min();
                checksum += (maxValue - minValue);
            }


            return checksum.ToString();
        }

        public string SolvePuzzlePart2()
        {

            string[] inputLines = InputFilesHelper.GetInputFileLines("day2.txt");
            int checksum = 0;

            foreach (string line in inputLines)
            {
                int[] nums = InputFilesHelper.ParseNumbersLine(line);

                (int num1, int num2) = FindDivisibleNums(nums);

                checksum += num1/num2;
            }


            return checksum.ToString();
        }

        private (int num1, int num2) FindDivisibleNums(int[] nums)
        {
            Array.Sort(nums);

            int num1, num2;

            for (int i = 0; i < (nums.Length - 1); i++)
            {
                num2 = nums[i];

                for (int j = i+1; j < nums.Length; j++)
                {
                    num1 = nums[j];

                    if (num1 % num2 == 0)
                    {
                        return (num1, num2);
                    }
                }
            }

            return (0,0);
        }
    }
}
