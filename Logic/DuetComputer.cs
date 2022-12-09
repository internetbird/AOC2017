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
    public class DuetComputer : ComputerSimulator<DuetComputerInstruction, DuetComputerInstructionType>
    {

        private long? _lastFrequencyPlayed = null;
        private long? _firstRecoveredFrequency = null;
        private long _mulInstunctionCounter = 0;

        public DuetComputer(DuetComputerInstructionParser parser) : base(parser){}

        protected override void ExecuteInsturction(DuetComputerInstruction instructionToExecute)
        {
            switch (instructionToExecute.Type)
            {
                case DuetComputerInstructionType.PlaySound:
                    long frequencyToPlay = GetOperandValue(instructionToExecute.Operand1);
                    _lastFrequencyPlayed = frequencyToPlay;
                    _programCounter++;
                    break;
                case DuetComputerInstructionType.SetValue:
                    long valueToSet = GetOperandValue(instructionToExecute.Operand2);
                    SetRegisterValue(instructionToExecute.Operand1, valueToSet);
                    _programCounter++;
                    break;
                case DuetComputerInstructionType.Add:
                    long valueToAdd = GetOperandValue(instructionToExecute.Operand2);
                    long addedRegsiter = GetRegisterValue(instructionToExecute.Operand1) + valueToAdd;
                    SetRegisterValue(instructionToExecute.Operand1, addedRegsiter);
                    _programCounter++;
                    break;
                case DuetComputerInstructionType.Subtruct:
                    long valueToSubtruct = GetOperandValue(instructionToExecute.Operand2);
                    long subtrcutResult = GetRegisterValue(instructionToExecute.Operand1) - valueToSubtruct;
                    SetRegisterValue(instructionToExecute.Operand1, subtrcutResult);
                    _programCounter++;
                    break;
                case DuetComputerInstructionType.Multiply:
                    long valueToMultiply = GetOperandValue(instructionToExecute.Operand2);
                    long multipliedRegister = GetRegisterValue(instructionToExecute.Operand1) * valueToMultiply;
                    SetRegisterValue(instructionToExecute.Operand1, multipliedRegister);
                    _mulInstunctionCounter++;
                    _programCounter++;
                    break;
                case DuetComputerInstructionType.Modulo:
                    long valueToModulo = GetOperandValue(instructionToExecute.Operand2);
                    long moduloRegister = GetRegisterValue(instructionToExecute.Operand1) % valueToModulo;
                    SetRegisterValue(instructionToExecute.Operand1, moduloRegister);
                    _programCounter++;
                    break;
                case DuetComputerInstructionType.RecoverFrequency:
                    long valueToRecoverFrequency = GetOperandValue(instructionToExecute.Operand1);
                    if (valueToRecoverFrequency != 0 && _firstRecoveredFrequency == null)
                    {
                        _firstRecoveredFrequency = _lastFrequencyPlayed;
                        _programCounter = int.MaxValue; //Finish execution
                    } else
                    {
                        _programCounter++;
                    }
                   
                    break;
                case DuetComputerInstructionType.JumpGreaterThenZero:
                    long checkGreaterThenZero = GetOperandValue(instructionToExecute.Operand1);
                    if (checkGreaterThenZero > 0)
                    {
                        _programCounter += (int)GetOperandValue(instructionToExecute.Operand2);
                    } else
                    {
                        _programCounter++;
                    }
                break;
                case DuetComputerInstructionType.JumpNotZero:
                    long checkNotZero = GetOperandValue(instructionToExecute.Operand1);
                    if (checkNotZero !=  0)
                    {
                        _programCounter += (int)GetOperandValue(instructionToExecute.Operand2);
                    }
                    else
                    {
                        _programCounter++;
                    }
                    break;
            }
        }

        public long GetFirstRecoveredFrequency() => _firstRecoveredFrequency.Value;
        public long GetMulInstunctionInvokeCounter() => _mulInstunctionCounter;

    }
}
