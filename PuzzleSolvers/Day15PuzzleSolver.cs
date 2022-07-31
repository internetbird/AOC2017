using AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day15PuzzleSolver : IPuzzleSolver
    {
        //Test Values
        //private const int GeneratorAInitialValue = 65;
        //private const int GeneratorBInitialValue = 8921;

        private const int GeneratorAFactor = 16807;
        private const int GeneratorBFactor = 48271;

        private const int GeneratorAInitialValue = 722;
        private const int GeneratorBInitialValue = 354;

        public string SolvePuzzlePart1()
        {
            int judgeCount = 0;

            int generatorAPrevValue = GeneratorAInitialValue;
            int generatorBPrevValue = GeneratorBInitialValue;

            for (int i = 0; i < 40_000_000; i++)
            {
                int generatorAValue = CalculateNextValue(generatorAPrevValue, GeneratorAFactor);
                int generatorBValue = CalculateNextValue(generatorBPrevValue, GeneratorBFactor);

                if (IsLowest16BitMatch(generatorAValue, generatorBValue))
                {
                    judgeCount++;
                }

                generatorAPrevValue = generatorAValue;
                generatorBPrevValue = generatorBValue;

                if (i%100_000 == 0)
                {
                    Console.WriteLine($"Calculated {i} value pairs, judgeCount = {judgeCount}");
                }

            }

            return judgeCount.ToString();
        }

        private bool IsLowest16BitMatch(int generatorAValue, int generatorBValue)
        {
           string aValueBinary = Convert.ToString(generatorAValue, 2).PadLeft(32, '0');
           string bValueBinary = Convert.ToString(generatorBValue, 2).PadLeft(32, '0');

            return aValueBinary.TakeLast(16)
                .SequenceEqual(bValueBinary.TakeLast(16));
        }

        private int CalculateNextValue(int prevValue, int factor, int?  divisiableBy = null)
        {
           ulong ulongPrevValue = Convert.ToUInt64(prevValue);
           ulong ulongFactor = Convert.ToUInt64(factor);

            int nextValue = (int)((ulongPrevValue * ulongFactor) % 2147483647);

            while(divisiableBy.HasValue && (nextValue % divisiableBy.Value != 0))
            {
                ulongPrevValue = Convert.ToUInt64(nextValue);
                nextValue = (int)((ulongPrevValue * ulongFactor) % 2147483647);
            }

            return nextValue;
        }

        public string SolvePuzzlePart2()
        {
            int judgeCount = 0;

            int generatorAPrevValue = GeneratorAInitialValue;
            int generatorBPrevValue = GeneratorBInitialValue;

            for (int i = 0; i < 5_000_000; i++)
            {
                int generatorAValue = CalculateNextValue(generatorAPrevValue, GeneratorAFactor, 4);
                int generatorBValue = CalculateNextValue(generatorBPrevValue, GeneratorBFactor, 8);

                if (IsLowest16BitMatch(generatorAValue, generatorBValue))
                {
                    judgeCount++;
                }

                generatorAPrevValue = generatorAValue;
                generatorBPrevValue = generatorBValue;

                if (i % 100_000 == 0)
                {
                    Console.WriteLine($"Calculated {i} value pairs, judgeCount = {judgeCount}");
                }
            }

            return judgeCount.ToString();
        }
    }
}
