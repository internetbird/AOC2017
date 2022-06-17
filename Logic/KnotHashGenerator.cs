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


        public List<int> GenerateHashSequence(List<int> lengths)
        {
            int currentPosition = 0;
            int skipSize = 0;

            List<int>  hash = ListCrow.GenerateIntegerSequence(0, _numOfElements - 1);

            for (int i = 0; i < lengths.Count; i++)
            {
                int currLength = lengths[i];
                hash = CalculateNextHashSequence(hash, currentPosition, currLength);
                currentPosition = (currentPosition + currLength + skipSize) % _numOfElements;
                skipSize++;
            }

            return hash;
        }

        public string GenerateHash(List<int> lengths)
        {
            int currentPosition = 0;
            int skipSize = 0;

            List<int> hashSequence = ListCrow.GenerateIntegerSequence(0, _numOfElements - 1);

            for (int round = 0; round < 64; round++)
            {
                for (int i = 0; i < lengths.Count; i++)
                {
                    int currLength = lengths[i];
                    hashSequence = CalculateNextHashSequence(hashSequence, currentPosition, currLength);
                    currentPosition = (currentPosition + currLength + skipSize) % _numOfElements;
                    skipSize++;
                }
            }

            var resultHash = string.Empty;

            for (int i = 0; i < _numOfElements; i+=16)
            {
                var currBlock = hashSequence.Skip(i).Take(16);
                resultHash += GetHexBitwiseXORValue(currBlock);
            }

            return resultHash;
        }

        private string GetHexBitwiseXORValue(IEnumerable<int> currBlock)
        {
            int xorValue = 0;

            foreach (var item in currBlock)
            {
                xorValue = xorValue ^ item;
            }

            var hexString = Convert.ToString(xorValue, 16).PadLeft(2, '0');
            return hexString;
        }

        private List<int> CalculateNextHashSequence(List<int> hash, int currentPosition,  int length)
        {
            var nextHash = hash.ReversePart(currentPosition, length);
            return nextHash;
        }
    }
}
