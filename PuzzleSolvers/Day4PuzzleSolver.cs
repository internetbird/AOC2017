using AOC2017.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2017.PuzzleSolvers
{
    public class Day4PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day4.txt");

            int numOfValidPassphrases = 0;

            foreach (string line in inputLines)
            {
                if (IsValidPassPhrase(line))
                {
                    numOfValidPassphrases++;
                }
            }
            return numOfValidPassphrases.ToString();

        }

        private bool IsValidPassPhrase(string line)
        {
            string[] phrases = line.Split(' ');

            var hashSet = new HashSet<string>();

            foreach (string phrase in phrases)
            {
                if (hashSet.Contains(phrase))
                {
                    return false;
                }
                hashSet.Add(phrase);
            }

            return true;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
