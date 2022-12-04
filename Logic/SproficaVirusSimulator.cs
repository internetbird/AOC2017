using AOC2017.Models;
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
        private Grid<VirusNodeState> _nodesNetwork2;
        private int _currentRowIndex;
        private int _currentColumnIndex;
        private Direction _currentDirection;
        private int _infectionsCounter;
        private readonly int _networkSize;


        public SproficaVirusSimulator(int networkSize = 125)
        {
            _networkSize = networkSize;
        }


        public int RunSimulation(Grid<bool> initialGrid, int numOfBursts)
        {
            int burstCounter = 0;

            _infectionsCounter = 0;

            InitNodesNetwork(initialGrid);
            _currentRowIndex = _networkSize / 2;
            _currentColumnIndex = _networkSize / 2;
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

        public int RunSimulation2(Grid<VirusNodeState> initialGrid, int numOfBursts)
        {
            int burstCounter = 0;
            _infectionsCounter = 0;

            InitNodesNetwork2(initialGrid);

            _currentRowIndex = _networkSize / 2;
            _currentColumnIndex = _networkSize / 2;
            _currentDirection = Direction.Up;

            while (burstCounter < numOfBursts)
            {
                VirusNodeState currentNodeState = _nodesNetwork2.GetItem(_currentRowIndex, _currentColumnIndex);


                switch(currentNodeState)
                {
                    case VirusNodeState.Clean:
                        _currentDirection = _currentDirection.TurnLeft();
                        _nodesNetwork2.SetItem(VirusNodeState.Weakended, _currentRowIndex, _currentColumnIndex);

                        break;
                    case VirusNodeState.Weakended:
                        _nodesNetwork2.SetItem(VirusNodeState.Infected, _currentRowIndex, _currentColumnIndex);
                        _infectionsCounter++;
                        break;
                    case VirusNodeState.Infected:
                        _currentDirection = _currentDirection.TurnRight();
                        _nodesNetwork2.SetItem(VirusNodeState.Flagged, _currentRowIndex, _currentColumnIndex);
                        break;
                    case VirusNodeState.Flagged:
                        _currentDirection = _currentDirection.Reverse();
                        _nodesNetwork2.SetItem(VirusNodeState.Clean, _currentRowIndex, _currentColumnIndex);
                        break;
                }

                MoveToNextNode();
                burstCounter++;
            }

            return _infectionsCounter;
        }

        private void InitNodesNetwork2(Grid<VirusNodeState> initialGrid)
        {
            _nodesNetwork2 = new Grid<VirusNodeState>(_networkSize, _networkSize);
            _nodesNetwork2.SetSubGrid((_networkSize - 25) / 2, (_networkSize - 25) / 2, initialGrid);
        }

        private void InitNodesNetwork(Grid<bool> initialGrid)
        {
            _nodesNetwork = new Grid<bool>(_networkSize, _networkSize);
            _nodesNetwork.SetSubGrid((_networkSize-25)/2, (_networkSize-25)/2, initialGrid);
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
