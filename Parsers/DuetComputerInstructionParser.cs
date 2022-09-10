using AOC2017.Models;
using BirdLib.AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Parsers
{
    public class DuetComputerInstructionParser : IComputerInstructionParser<DuetComputerInstruction, DuetComputerInstuctionType>
    {
        public DuetComputerInstruction ParseInstruction(string line)
        {
            var instruction = new DuetComputerInstruction();

            string[] instructionParts = line.Split();

            DuetComputerInstuctionType type = DuetComputerInstuctionType.NotSet;

            switch (instructionParts[0])
            {
                case "set":
                    type = DuetComputerInstuctionType.SetValue;
                    break;
                case "snd":
                    type = DuetComputerInstuctionType.PlaySound;
                    break;
                case "add":
                    type = DuetComputerInstuctionType.Add;
                    break;
                case "mul":
                    type = DuetComputerInstuctionType.Multiply;
                    break;
                case "mod":
                    type = DuetComputerInstuctionType.Modulo;
                    break;
                case "rcv":
                    type = DuetComputerInstuctionType.RecoverFrequency;
                    break;
                case "jgz":
                    type = DuetComputerInstuctionType.JumpGreaterThenZero;
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
