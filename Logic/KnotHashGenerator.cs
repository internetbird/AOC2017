using BirdLib;
using BirdLib.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class KnotHashGenerator
    {
        private int _numOfElements;

        public KnotHashGenerator(int numOfElements = 256)
        {
            _numOfElements = numOfElements;
        }


        public List<int> GenerateHash(List<int> lengths)
        {
            int currentPosition = 0;
            int skipSize = 0;

            List<int>  hash = ListCrow.GenerateIntegerSequence(0, _numOfElements - 1);

            for (int i = 0; i < lengths.Count; i++)
            {
                int currLength = lengths[i];
                hash = CalculateNextHashStep(hash, currentPosition, currLength);
                currentPosition = (currentPosition + currLength + skipSize) % _numOfElements;
                skipSize++;
            }

            return hash;
        }

        private List<int> CalculateNextHashStep(List<int> hash, int currentPosition,  int length)
        {
            var nextHash = hash.ReversePart(currentPosition, length);
            return nextHash;
        }
    }
}
