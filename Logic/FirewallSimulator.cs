using AOC2017.Models;
using BirdLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class FirewallSimulator
    {
        private List<FirewallLayer> _layers;

        public FirewallSimulator(List<FirewallLayer> layers)
        {
            _layers = layers;
        }

        private FirewallState GetInitialState(List<FirewallLayer> layers, int delay = 0)
        {
            var state = new FirewallState();

            foreach (var layer in layers)
            {
                var scannerPosition = new ScannerPosition();
                scannerPosition.MoveDirection = GetInitialMoveDirection(delay, layer.Range);
                scannerPosition.PositionIndex = GetInitialPositionIndex(delay, layer.Range);
                scannerPosition.LayerRange = layer.Range;
                scannerPosition.LayerIndex = layer.Depth;

                state.ScannerPositions.Add(scannerPosition);
            }

            return state;
        }


        private VerticalDirection GetInitialMoveDirection(int delay, int range)
        {
            int singleCyclePosition = delay % ((range - 1) * 2);
            return singleCyclePosition < (range - 1) ? VerticalDirection.Up : VerticalDirection.Down;
        }

        private int GetInitialPositionIndex(int delay, int range)
        {
            int singleCyclePosition =  delay % ((range-1)*2);

            if (singleCyclePosition < range)
            {
                return singleCyclePosition;
            } else
            {
                return ((range-1) * 2) - singleCyclePosition;
            }

        }


        /// <summary>
        /// Runs the firewall simulation start to end
        /// </summary>
        /// <returns>The total serverity</returns>
        public int Run()
        {
            int totalSeverity = 0;

            FirewallState state = GetInitialState(_layers);

            var maxDepth = _layers.Max(layer => layer.Depth);

            for (int i = 0; i <= maxDepth; i++)
            {
                totalSeverity += GetSeverityFor(i, state);
                state = CalculateNextState(state);

            }
            return totalSeverity;
        }
        /// <summary>
        /// Runs a pass-through simulation
        /// </summary>
        /// <param name="delay"></param>
        /// <returns>True is the passthrough was successful, false otherwise</returns>
        public bool RunPassThrough(int delay = 0)
        {
            FirewallState state = GetInitialState(_layers, delay);

            var maxDepth = _layers.Max(layer => layer.Depth);

            for (int i = 0; i <= maxDepth; i++)
            {
                bool isCaught =  IsCaughtAt(i, state);
                
                if(isCaught)
                {
                    return false;
                }

                state = CalculateNextState(state);
            }

            return true;

        }

        private int GetSeverityFor(int layerIndex, FirewallState state)
        {
            ScannerPosition position = state.GetScannerPositionForLayer(layerIndex);
            if (position != null && position.PositionIndex == 0)
            {
                return layerIndex * position.LayerRange;
            }

            return 0;
        }

        private bool IsCaughtAt(int layerIndex, FirewallState state)
        {
            ScannerPosition position = state.GetScannerPositionForLayer(layerIndex);
            return position != null && position.PositionIndex == 0;
        }

        private FirewallState CalculateNextState(FirewallState state)
        {
            var nextState = new FirewallState();

            foreach (ScannerPosition position in state.ScannerPositions)
            {
                var newPosition = new ScannerPosition();

                newPosition.LayerIndex = position.LayerIndex;
                newPosition.LayerRange = position.LayerRange;

                int newPositionIndex = position.PositionIndex + (int)position.MoveDirection;

                newPosition.PositionIndex = newPositionIndex;

                if (newPositionIndex == 0)
                {
                    newPosition.MoveDirection = VerticalDirection.Up;

                } else if (newPositionIndex == (position.LayerRange - 1))
                {
                    newPosition.MoveDirection = VerticalDirection.Down;
                } else
                {
                    newPosition.MoveDirection = position.MoveDirection;
                }

                nextState.ScannerPositions.Add(newPosition);
            }

            return nextState;
        }
    }
}
