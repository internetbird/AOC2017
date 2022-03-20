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
        public int Run()        {

            int redistributionCounter = 0;
            bool sameConfigurationReached = false;

            while (!sameConfigurationReached)
            {
                List<int> nextConfiguration = RedistributeBlocks();
                redistributionCounter++;

                if (ConfigurationHistoryContains(nextConfiguration))
                {
                    sameConfigurationReached = true;

                } else
                {
                    _configurationHistory.Add(nextConfiguration);
                    _currentBlockConfiguration = nextConfiguration;
                }
            }

            return redistributionCounter;
           
        }

        private bool ConfigurationHistoryContains(List<int> nextConfiguration)
        {
            foreach  (List<int> item in _configurationHistory)
            {
                if (ConfigurationAreTheSame(item, nextConfiguration))
                {
                    return true;
                }
            }

            return false;
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
