using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2017.Logic
{
    public class SpiralMemoryCalculator
    {

        public int GetSpiralIndexForLocation(int location)
        {

            int index = 0;
            int currIndexLocationStart = 1, currIndexLocationEnd = 1;

            while (!(location >= currIndexLocationStart && location <= currIndexLocationEnd))
            {
                index++;
                currIndexLocationStart = currIndexLocationEnd + 1;
                int currSpiralSideLength = (index * 2 + 1);
                currIndexLocationEnd = currIndexLocationStart + (currSpiralSideLength * 2) + (currSpiralSideLength - 2) * 2 - 1;
            }

            return index;
        }
    }
}
