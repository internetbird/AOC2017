using AOC;
using AOC2017.Logic;
using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day25PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            TuringMachineConfiguration configuration = GetConfiguration();

            var machine = new TuringMachine(configuration);

            machine.Run(12656374);

            long result = machine.GetDiagnosticChecksum();
            return result.ToString();
        }

        private TuringMachineConfiguration GetConfiguration()
        {
            var configuration = new TuringMachineConfiguration();

            configuration.InitialState = "A";


            //State "A" rule
            configuration.AddRule("A", new TuringMachineRule
            {
                ZeroValueAction = new TuringMachineAction
                {
                    WriteValue = true,
                    HeadMove = 1,
                    TransitionToState = "B"
                },
                OneValueAction = new TuringMachineAction
                {
                    WriteValue = false,
                    HeadMove = -1,
                    TransitionToState = "C"
                }
            });

            //State "B" rule
            configuration.AddRule("B", new TuringMachineRule
            {
                ZeroValueAction = new TuringMachineAction
                {
                    WriteValue = true,
                    HeadMove = -1,
                    TransitionToState = "A"
                },
                OneValueAction = new TuringMachineAction
                {
                    WriteValue = true,
                    HeadMove = -1,
                    TransitionToState = "D"
                }
            });

            //State "C" rule
            configuration.AddRule("C", new TuringMachineRule
            {
                ZeroValueAction = new TuringMachineAction
                {
                    WriteValue = true,
                    HeadMove = 1,
                    TransitionToState = "D"
                },
                OneValueAction = new TuringMachineAction
                {
                    WriteValue = false,
                    HeadMove = 1,
                    TransitionToState = "C"
                }
            });

            //State "D" rule
            configuration.AddRule("D", new TuringMachineRule
            {
                ZeroValueAction = new TuringMachineAction
                {
                    WriteValue = false,
                    HeadMove = -1,
                    TransitionToState = "B"
                },
                OneValueAction = new TuringMachineAction
                {
                    WriteValue = false,
                    HeadMove = 1,
                    TransitionToState = "E"
                }
            });

            //State "E" rule
            configuration.AddRule("E", new TuringMachineRule
            {
                ZeroValueAction = new TuringMachineAction
                {
                    WriteValue = true,
                    HeadMove = 1,
                    TransitionToState = "C"
                },
                OneValueAction = new TuringMachineAction
                {
                    WriteValue = true,
                    HeadMove = -1,
                    TransitionToState = "F"
                }
            });

            //State "F" rule
            configuration.AddRule("F", new TuringMachineRule
            {
                ZeroValueAction = new TuringMachineAction
                {
                    WriteValue = true,
                    HeadMove = -1,
                    TransitionToState = "E"
                },
                OneValueAction = new TuringMachineAction
                {
                    WriteValue = true,
                    HeadMove = 1,
                    TransitionToState = "A"
                }
            });

            return configuration;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
