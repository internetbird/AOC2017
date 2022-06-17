using AOC;
using AOC2017.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day10PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string inputText = InputFilesHelper.GetInputFileText("day10.txt");

            List<int> inputLengths = inputText.Split(',').Select(int.Parse).ToList();

            var hashGenerator = new KnotHashGenerator();

            List<int> hash = hashGenerator.GenerateHashSequence(inputLengths);

            return (hash[0]*hash[1]).ToString();

        }

        public string SolvePuzzlePart2()
        {

            List<int> lengths = ConvertToASCIISequence("157,222,1,2,177,254,0,228,159,140,249,187,255,51,76,30");

            var hashGenerator = new KnotHashGenerator();

            string hash = hashGenerator.GenerateHash(lengths);
            return hash;
        }

        private List<int> ConvertToASCIISequence(string inputText)
        {
            var sequence = new List<int>();

            for (int i = 0; i < inputText.Length; i++)
            {
                sequence.Add((int)inputText[i]);
            }

            sequence.AddRange(new List<int> { 17, 31, 73, 47, 23 });

            return sequence;
        }
    }
}
