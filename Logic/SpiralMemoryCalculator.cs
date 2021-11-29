using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2017.Logic
{
    public class SpiralMemoryCalculator
    {

        public (int squareSize, int minValue, int maxValue) GetSquareDetailsForValue(int value)
        {
            int currSquareSize = 3;
            int minValue = 2;
            int maxValue = 9;


            while (!(value >= minValue && value <= maxValue)) {
                currSquareSize = currSquareSize + 2;

                minValue = maxValue + 1;
                maxValue = minValue + (currSquareSize * 4) - 5;
            }


            return (currSquareSize, minValue, maxValue);

        }

        public int CalculateDistance(int value, int topRight, int topLeft, int bottomLeft, int bottomRight)
        {
            int squareSize = topLeft - topRight + 1;

            int horizontalDistace = 0, verticalDistace = 0;

            if (value >= topRight && value <= topLeft) //top side
            {
                int midValue = (topLeft + topRight) / 2;
                horizontalDistace = Math.Abs(value - midValue);
                verticalDistace = (squareSize - 1) / 2;

            } else if  (value > topLeft && value < bottomLeft) //left side
            {
                horizontalDistace = (squareSize - 1) / 2;
                int midValue = (topLeft + bottomLeft) / 2;
                verticalDistace = Math.Abs(value - midValue);

            } else if (value >= bottomLeft && value <= bottomRight) //bottom side
            {
                verticalDistace = (squareSize - 1) / 2;
                int midValue = (bottomLeft + bottomRight) / 2;
                horizontalDistace = Math.Abs(value - midValue);
            }
            else //right side 
            {
                horizontalDistace = (squareSize - 1) / 2;
                int midValue = (topRight + (topRight - squareSize  + 1)) / 2;
                verticalDistace = Math.Abs(value - midValue);
            }

            return horizontalDistace + verticalDistace;
        }

        public (int topRight, int topLeft, int bottomLeft) GetSquareEdgeValues(int squareSize, int minValue)
        {
            int topRight = minValue + squareSize - 2;
            int topLeft = topRight + squareSize - 1;
            int bottomLeft = topLeft + squareSize - 1;

            return (topRight, topLeft, bottomLeft);
        }
    }
}
