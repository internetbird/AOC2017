using AOC2017.Models;
using BirdLib.AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Parsers
{
    public class Duet2ComputerInstructionParser : IComputerInstructionParser<Duet2ComputerInstruction, Duet2ComputerInstructionType>
    {
        public Duet2ComputerInstruction ParseInstruction(string line)
        {
            var instruction = new Duet2ComputerInstruction();

            string[] instructionParts = line.Split();

            Duet2ComputerInstructionType type = Duet2ComputerInstructionType.NotSet;

            switch (instructionParts[0])
            {
                case "set":
                    type = Duet2ComputerInstructionType.SetValue;
                    break;
                case "snd":
                    type = Duet2ComputerInstructionType.Send;
                    break;
                case "add":
                    type = Duet2ComputerInstructionType.Add;
                    break;
                case "mul":
                    type = Duet2ComputerInstructionType.Multiply;
                    break;
                case "mod":
                    type = Duet2ComputerInstructionType.Modulo;
                    break;
                case "rcv":
                    type = Duet2ComputerInstructionType.Receive;
                    break;
                case "jgz":
                    type = Duet2ComputerInstructionType.JumpGreaterThenZero;
                    break;

            }


            string operand1 = instructionParts[1];
            string operand2 = null;
            if (instructionParts.Length > 2)
            {
                operand2 = instructionParts[2];
            }

            instruction.Type = type;
            instruction.Operand1 = operand1;
            instruction.Operand2 = operand2;

            return instruction;
        }
    }
}
