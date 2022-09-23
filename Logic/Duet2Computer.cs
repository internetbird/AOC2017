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
    public class Duet2Computer : ComputerSimulator<Duet2ComputerInstruction, Duet2ComputerInstructionType>
    {

        private Queue<long> _valuesQueue = new Queue<long>();
        private Duet2Computer _valuesReceiver;
  
        private Duet2ComputerState _state = Duet2ComputerState.Running;
        private int _valuesSentCounter = 0;

        public Duet2Computer(Duet2ComputerInstructionParser parser, int programID) : base(parser) 
        {
            SetRegisterValue("p", programID);
        }

        public void ReceiveValue(long value)
        {
            _valuesQueue.Enqueue(value);
        }

        protected override Duet2ComputerInstruction GetNextInstructionToExecute()
        {
            if (_state == Duet2ComputerState.Running)
            {
                return base.GetNextInstructionToExecute();
            } else
            {
                return null;
            }
        }

        protected override void ExecuteInsturction(Duet2ComputerInstruction instructionToExecute)
        {
            switch (instructionToExecute.Type)
            {
                case Duet2ComputerInstructionType.Send:
                    long valueToSend = GetOperandValue(instructionToExecute.Operand1);
                    if (_valuesReceiver != null)
                    {
                        _valuesReceiver.ReceiveValue(valueToSend);
                        _valuesSentCounter++;
                    }
                    _programCounter++;
                    break;
                case Duet2ComputerInstructionType.SetValue:
                    long valueToSet = GetOperandValue(instructionToExecute.Operand2);
                    SetRegisterValue(instructionToExecute.Operand1, valueToSet);
                    _programCounter++;
                    break;
                case Duet2ComputerInstructionType.Add:
                    long valueToAdd = GetOperandValue(instructionToExecute.Operand2);
                    long addedRegsiter = GetRegisterValue(instructionToExecute.Operand1) + valueToAdd;
                    SetRegisterValue(instructionToExecute.Operand1, addedRegsiter);
                    _programCounter++;
                    break;
                case Duet2ComputerInstructionType.Multiply:
                    long valueToMultiply = GetOperandValue(instructionToExecute.Operand2);
                    long multipliedRegister = GetRegisterValue(instructionToExecute.Operand1) * valueToMultiply;
                    SetRegisterValue(instructionToExecute.Operand1, multipliedRegister);
                    _programCounter++;
                    break;
                case Duet2ComputerInstructionType.Modulo:
                    long valueToModulo = GetOperandValue(instructionToExecute.Operand2);
                    long moduloRegister = GetRegisterValue(instructionToExecute.Operand1) % valueToModulo;
                    SetRegisterValue(instructionToExecute.Operand1, moduloRegister);
                    _programCounter++;
                    break;
                case Duet2ComputerInstructionType.Receive:

                    if (_valuesQueue.Count > 0)
                    {
                        //We now have values so we can resume the execution
                        if (_state == Duet2ComputerState.Waiting)
                        {
                            _state = Duet2ComputerState.Running;
                        }

                        long valueToReceive = _valuesQueue.Dequeue();
                        SetRegisterValue(instructionToExecute.Operand1, valueToReceive);
                        _programCounter++;
                    } else
                    {
                        _state = Duet2ComputerState.Waiting;
                    }
                   
                    break;
                case Duet2ComputerInstructionType.JumpGreaterThenZero:
                    long checkGreaterThenZero = GetOperandValue(instructionToExecute.Operand1);
                    if (checkGreaterThenZero > 0)
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


        public void SetValueReceiver(Duet2Computer receiver)
        {
            _valuesReceiver = receiver;
        }

        public int GetValuesSentCounter() => _valuesSentCounter;

        /// <summary>
        /// Resumes a waiting program
        /// </summary>
        /// <returns>The number of commmand that were executed</returns>
        public int ResumeProgram()
        {
            int numOfCommandsExecuted = 0;

            if (_valuesQueue.Any() && _state == Duet2ComputerState.Waiting)
            {
                _state = Duet2ComputerState.Running;
            }

            Duet2ComputerInstruction instructionToExecute = GetNextInstructionToExecute();

            while (instructionToExecute != null)
            {
                ExecuteInsturction(instructionToExecute);
                numOfCommandsExecuted++;
                instructionToExecute = GetNextInstructionToExecute();
            }

            return numOfCommandsExecuted;
        }
    }
}
