using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class TuringMachine
    {
        private long _headPosition;
        private string _currentState;
        private Dictionary<string,TuringMachineRule> _rules;
        private List<long> _headPositionsThatHaveOneValue;

        public TuringMachine(TuringMachineConfiguration configuration) 
        {
            _currentState = configuration.InitialState;
            _rules= configuration.Rules;
            _headPositionsThatHaveOneValue = new List<long>();

        }

        public void Run(long numOfSteps)
        {
            _headPosition = 0;

            while (numOfSteps > 0)
            {
                TuringMachineRule currentRule = _rules[_currentState];

                if (_headPositionsThatHaveOneValue.Contains(_headPosition))
                {
                    //Run the 'One' action

                    //Remove the 'One' value if required
                    if (!currentRule.OneValueAction.WriteValue)
                    {
                        _headPositionsThatHaveOneValue.Remove(_headPosition);
                    }

                    _headPosition += currentRule.OneValueAction.HeadMove;
                    _currentState = currentRule.OneValueAction.TransitionToState;

                }
                else //Run the 'Zero' action
                {
                    //Add 'One' value if required
                    if (currentRule.ZeroValueAction.WriteValue)
                    {
                        _headPositionsThatHaveOneValue.Add(_headPosition);
                    }

                    _headPosition += currentRule.ZeroValueAction.HeadMove;
                    _currentState = currentRule.ZeroValueAction.TransitionToState;

                }

                numOfSteps--;
            }
        }

        public long GetDiagnosticChecksum()
        {
            return _headPositionsThatHaveOneValue.Count();
        }
    }
}
