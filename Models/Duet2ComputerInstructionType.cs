using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.Models
{
    public enum Duet2ComputerInstructionType
    {
        NotSet,
        Send,
        SetValue,
        Add,
        Multiply,
        Modulo,
        Receive,
        JumpGreaterThenZero
    }
}
