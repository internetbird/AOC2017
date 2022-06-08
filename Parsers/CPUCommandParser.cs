using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Parsers
{
    public static class CPUCommandParser
    {

        /// <summary>
        /// Parses commands in the format : 'bz dec 602 if hri != -10'
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static CPUCommand ParseCommand(string commandText)
        {
            string[] mainParts = commandText.Split("if");

            string actionPart = mainParts[0].Trim();
            string conditionPart = mainParts[1].Trim();

            var command = new CPUCommand();

            string[] actionParts = actionPart.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string registerToUpdate = actionParts[0];
            string commandStr = actionParts[1];
            string commandOperand = actionParts[2];

            command.RegisterToUpdate = registerToUpdate;
            command.CommandType = commandStr == "inc" ? CPUCommandType.Increase : CPUCommandType.Decrease;
            command.CommandOperand = int.Parse(commandOperand);
            command.Condition = conditionPart;

            return command;
        }
    }
}
