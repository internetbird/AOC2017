using AOC2017.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2017.PuzzleSolvers
{
    public class Day3PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var calculator = new SpiralMemoryCalculator();

            int value = 312051;

            (int squareSize, int minValue, int maxValue) =  calculator.GetSquareDetailsForValue(value);
            (int topRight, int topLeft, int bottomLeft) = calculator.GetSquareEdgeValues(squareSize, minValue);

            int manhattenDistance = calculator.CalculateDistance(value, topRight, topLeft, bottomLeft, maxValue);

            return manhattenDistance.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
