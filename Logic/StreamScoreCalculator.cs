using BirdLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class StreamScoreCalculator
    {
        public int CalculateStreamScore(string stream)
        {
            int currScore = 0;
            int totalScore = 0;
            bool inGarbageSection = false;
            bool ignoreNextChar = false;

            for (int i = 0; i < stream.Length; i++)
            {
                if (ignoreNextChar)
                {
                    ignoreNextChar = false;
                    continue;
                }

                char currStreamChar = stream[i];

                switch (currStreamChar)
                {
                    
                    case '{':

                        if (!inGarbageSection)
                        {
                            currScore++;
                        }
                      
                        break;
                    case '}':
                        if (!inGarbageSection)
                        {
                            totalScore += currScore;
                            currScore--;
                        }
                      
                        break;
                    case '<':
                        inGarbageSection = true;
                        break;
                    case '>':
                        inGarbageSection = false;
                        break;
                    case '!':
                        ignoreNextChar = true;
                        break;
                }
            }
            return totalScore;
        }
    }
}
