using AOC2017.Models;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class CPUSimulator
    {
        private Dictionary<string, int> _registers = new Dictionary<string, int>();


        public async Task RunCommands(List<CPUCommand> commands)
        {
            for(int i =0; i < commands.Count; i++)
            {
                CPUCommand command = commands[i];

                if (await EvaluateCondition(command.Condition))
                {
                    if (!_registers.ContainsKey(command.RegisterToUpdate))
                    {
                        _registers.Add(command.RegisterToUpdate, 0);
                    }

                    if (command.CommandType == CPUCommandType.Increase)
                    {
                        _registers[command.RegisterToUpdate] += command.CommandOperand;
                    } else
                    {
                        _registers[command.RegisterToUpdate] -= command.CommandOperand;
                    }
                }
            }

        }

        private async Task<bool> EvaluateCondition(string condition)
        {
            string conditionRegister = condition.Split(' ')[0].Trim();

            int registerValue = _registers.ContainsKey(conditionRegister)
                ? _registers[conditionRegister] : 0;

            string code = $"var {conditionRegister} = {registerValue}; return {condition};";
            var result = await CSharpScript.RunAsync(code);
            return (bool)result.ReturnValue;
        }

        public int GetMaxRegisterValue()
        {
            return _registers.Max(kvp => kvp.Value);
        }


    }
}
