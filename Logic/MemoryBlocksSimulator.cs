using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2017.Logic
{
    public class MemoryBlocksSimulator
    {
        private List<int> _currentBlockConfiguration;
        private List<List<int>> _configurationHistory;
        private readonly int NumOfMemoryBanks;


        public MemoryBlocksSimulator(List<int> initalConfiguration)
        {
            _currentBlockConfiguration = initalConfiguration;
            _configurationHistory = new List<List<int>>{ new List<int>(initalConfiguration)};

            NumOfMemoryBanks = initalConfiguration.Count;

        }

        /// <summary>
        /// Runs the simulator until a similar configuration is repeated
        /// </summary>
        /// <returns>The number of memory redistributions</returns>
        public (int numOfMemoryRedistributions, int loopLength) Run()        {

            int redistributionCounter = 0;
            int loopLength = -1;
            bool sameConfigurationReached = false;

            while (!sameConfigurationReached)
            {
                List<int> nextConfiguration = RedistributeBlocks();
                redistributionCounter++;


                (bool historyContainsConfiguraion, int historyIndex) = ConfigurationHistoryContains(nextConfiguration);

                if (historyContainsConfiguraion)
                {
                    sameConfigurationReached = true;
                    loopLength = redistributionCounter - historyIndex;

                } else
                {
                    _configurationHistory.Add(nextConfiguration);
                    _currentBlockConfiguration = nextConfiguration;
                }
            }

            return (redistributionCounter, loopLength);
           
        }

        private (bool contains, int historyIndex) ConfigurationHistoryContains(List<int> nextConfiguration)
        {

            for (int i = 0; i < _configurationHistory.Count; i++)
            {
                if (ConfigurationAreTheSame(_configurationHistory[i], nextConfiguration))
                {
                    return (true, i);
                }
            }

            return (false, -1);
        }

        private bool ConfigurationAreTheSame(List<int> item, List<int> nextConfiguration)
        {
            for (int i = 0; i < NumOfMemoryBanks; i++)
            {
                if (item[i] != nextConfiguration[i])
                {
                    return false;
                }
            }
            return true;
        }


        private List<int> RedistributeBlocks()
        {
            List<int> nextConfiguration = new List<int>(_currentBlockConfiguration);

            int maxBlocksBankIndex = GetMaxBlocksIndex();
            int numOfBlockToDistiribute = _currentBlockConfiguration[maxBlocksBankIndex];

            nextConfiguration[maxBlocksBankIndex] = 0;

            int distibuteIndex = (maxBlocksBankIndex + 1) % NumOfMemoryBanks;
            while (numOfBlockToDistiribute > 0)
            {
                nextConfiguration[distibuteIndex]++;
                numOfBlockToDistiribute--;
                distibuteIndex = (distibuteIndex + 1) % NumOfMemoryBanks;
            }


            return nextConfiguration;
        }

        private int GetMaxBlocksIndex()
        {
            int maxBlocksIndex = 0;
            int maxBlocksCount = _currentBlockConfiguration[0];

            for (int i = 1; i < NumOfMemoryBanks; i++)
            {
                if (_currentBlockConfiguration[i] > maxBlocksCount)
                {
                    maxBlocksIndex = i;
                    maxBlocksCount = _currentBlockConfiguration[i];
                }
            }

            return maxBlocksIndex;
        }
    }
}
