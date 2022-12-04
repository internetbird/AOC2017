using BirdLib.DataModels;
using BirdLib.Enums;
using BirdLib.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class SproficaVirusSimulator
    {
        private Grid<bool> _nodesNetwork;
        private int _currentRowIndex;
        private int _currentColumnIndex;
        private Direction _currentDirection;
        private int _infectionsCounter;
        private const int NetworkSize = 125;


        public int RunSimulation(Grid<bool> initialGrid, int numOfBursts)
        {
            int burstCounter = 0;

            _infectionsCounter = 0;

            InitNodesNetwork(initialGrid);
            _currentRowIndex = NetworkSize / 2;
            _currentColumnIndex = NetworkSize / 2;
            _currentDirection = Direction.Up;

            while (burstCounter < numOfBursts)
            {
                bool isCurrentNodeInfected = _nodesNetwork.GetItem(_currentRowIndex, _currentColumnIndex);


                if (isCurrentNodeInfected)
                {
                    _currentDirection = _currentDirection.TurnRight();
                    _nodesNetwork.SetItem(false, _currentRowIndex, _currentColumnIndex);
                }
                else
                {
                    _currentDirection = _currentDirection.TurnLeft();
                    _nodesNetwork.SetItem(true, _currentRowIndex, _currentColumnIndex);
                    _infectionsCounter++;
                }

                MoveToNextNode();
                burstCounter++;
           
            }
            return _infectionsCounter;

        }

        private void InitNodesNetwork(Grid<bool> initialGrid)
        {
            _nodesNetwork = new Grid<bool>(NetworkSize, NetworkSize);
            _nodesNetwork.SetSubGrid((NetworkSize-25)/2, (NetworkSize-25)/2, initialGrid);
        }

        private void MoveToNextNode()
        {
           switch(_currentDirection)
            {
                case Direction.Up:
                    _currentRowIndex--;
                    break;
                case Direction.Down:
                    _currentRowIndex++;
                    break;
                case Direction.Right:
                    _currentColumnIndex++;
                    break;
                case Direction.Left:
                    _currentColumnIndex--;
                    break;

            }
        }
    }
}
