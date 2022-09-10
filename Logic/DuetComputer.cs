using AOC2017.Models;
using AOC2017.Parsers;
using BirdLib.AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class DuetComputer : ComputerSimulator<DuetComputerInstruction, DuetComputerInstuctionType>
    {

        private int? _lastFrequencyPlayed = null;
        private int? _firstRecoveredFrequency = null;

        public DuetComputer(DuetComputerInstructionParser parser) : base(parser){}

        protected override void ExecuteInsturction(DuetComputerInstruction instructionToExecute)
        {
            switch (instructionToExecute.Type)
            {
                case DuetComputerInstuctionType.PlaySound:
                    int frequencyToPlay = GetOperandValue(instructionToExecute.Operand1);
                    _lastFrequencyPlayed = frequencyToPlay;
                    _programCounter++;
                    break;
                case DuetComputerInstuctionType.SetValue:
                    int valueToSet = GetOperandValue(instructionToExecute.Operand2);
                    SetRegisterValue(instructionToExecute.Operand1, valueToSet);
                    _programCounter++;
                    break;
                case DuetComputerInstuctionType.Add:
                    int valueToAdd = GetOperandValue(instructionToExecute.Operand2);
                    int addedRegsiter = GetRegisterValue(instructionToExecute.Operand1) + valueToAdd;
                    SetRegisterValue(instructionToExecute.Operand1, addedRegsiter);
                    _programCounter++;
                    break;
                case DuetComputerInstuctionType.Multiply:
                    int valueToMultiply = GetOperandValue(instructionToExecute.Operand2);
                    int multipliedRegister = GetRegisterValue(instructionToExecute.Operand1) * valueToMultiply;
                    SetRegisterValue(instructionToExecute.Operand1, multipliedRegister);
                    _programCounter++;
                    break;
                case DuetComputerInstuctionType.Modulo:
                    int valueToModulo = GetOperandValue(instructionToExecute.Operand2);
                    int moduloRegister = GetRegisterValue(instructionToExecute.Operand1) % valueToModulo;
                    SetRegisterValue(instructionToExecute.Operand1, moduloRegister);
                    _programCounter++;
                    break;
                case DuetComputerInstuctionType.RecoverFrequency:
                    int valueToRecoverFrequency = GetOperandValue(instructionToExecute.Operand1);
                    if (valueToRecoverFrequency != 0 && _firstRecoveredFrequency == null)
                    {
                        _firstRecoveredFrequency = _lastFrequencyPlayed;
                        _programCounter = int.MaxValue; //Finish execution
                    } else
                    {
                        _programCounter++;
                    }
                   
                    break;
                case DuetComputerInstuctionType.JumpGreaterThenZero:
                    int checkGreaterThenZero = GetOperandValue(instructionToExecute.Operand1);
                    if (checkGreaterThenZero > 0)
                    {
                        _programCounter += GetOperandValue(instructionToExecute.Operand2);
                    } else
                    {
                        _programCounter++;
                    }
                break;
            }
        }

        public int GetFirstRecoveredFrequency() => _firstRecoveredFrequency.Value;

    }
}
