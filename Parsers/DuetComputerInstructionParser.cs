using AOC2017.Models;
using BirdLib.AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Parsers
{
    public class DuetComputerInstructionParser : IComputerInstructionParser<DuetComputerInstruction, DuetComputerInstructionType>
    {
        public DuetComputerInstruction ParseInstruction(string line)
        {
            var instruction = new DuetComputerInstruction();

            string[] instructionParts = line.Split();

            DuetComputerInstructionType type = DuetComputerInstructionType.NotSet;

            switch (instructionParts[0])
            {
                case "set":
                    type = DuetComputerInstructionType.SetValue;
                    break;
                case "snd":
                    type = DuetComputerInstructionType.PlaySound;
                    break;
                case "add":
                    type = DuetComputerInstructionType.Add;
                    break;
                case "mul":
                    type = DuetComputerInstructionType.Multiply;
                    break;
                case "mod":
                    type = DuetComputerInstructionType.Modulo;
                    break;
                case "rcv":
                    type = DuetComputerInstructionType.RecoverFrequency;
                    break;
                case "jgz":
                    type = DuetComputerInstructionType.JumpGreaterThenZero;
                    break;
                case "jnz":
                    type = DuetComputerInstructionType.JumpNotZero;
                    break;
                case "sub":
                    type = DuetComputerInstructionType.Subtruct;
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
