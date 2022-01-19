using AOC;
using AOC2017.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2017.PuzzleSolvers
{
    public class Day1PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string input = InputFilesHelper.GetInputFileText("day1.txt");

            input = input.Remove(input.Length-1);

            var captchaCalculator = new CaptchaCalculator();
            int captch = captchaCalculator.CalculateCaptch(input);

            return captch.ToString();
        }

        public string SolvePuzzlePart2()
        {
            string input = InputFilesHelper.GetInputFileText("day1.txt");

            input = input.Remove(input.Length - 1);

            var captchaCalculator = new CaptchaCalculator();
            int captch = captchaCalculator.CalculateAdvancedCaptch(input);

            return captch.ToString();
        }
    }
}
