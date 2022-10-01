using BirdLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2017.Logic
{
    public class RoutingDiagramScanner
    {

        private string[] _inputLines;
        private int _currRowIndex;
        private int _currColumnIndex;
        private Direction _currDirection;

        private char CurrentChar => _inputLines[_currRowIndex][_currColumnIndex];

        public string ScanLetters(string[] inputLines)
        {
            var letters = string.Empty;

            _inputLines = inputLines;
            _currRowIndex = 0;
            _currColumnIndex = inputLines[0].IndexOf('|');
            _currDirection = Direction.Down;

            while(MoveToNextPosition())
            {
                if (Regex.IsMatch(CurrentChar.ToString(), "[A-Z]"))
                {
                    letters += CurrentChar;
                }
            }
            return letters;
        }

        private bool MoveToNextPosition()
        {
           switch (_currDirection)
            {
                case Direction.Down:
                    _currRowIndex++;
                    break;
                case Direction.Up:
                    _currRowIndex--;
                    break;
                case Direction.Right:
                    _currColumnIndex++;
                    break;
                case Direction.Left:
                    _currColumnIndex--;
                    break;

            }

            if (CurrentChar == '+')
            {
                if (_currDirection == Direction.Up || _currDirection == Direction.Down)
                {
                    char nextColumnChar = GetCharAtPosition(_currRowIndex, _currColumnIndex + 1);

                    if (nextColumnChar != 0 && !char.IsWhiteSpace(nextColumnChar))
                    {
                        _currDirection = Direction.Right;
                    } else
                    {
                        _currDirection = Direction.Left;
                    }

                } else //right or left, switching to up or down
                {
                    char nextRowChar = GetCharAtPosition(_currRowIndex + 1, _currColumnIndex);

                    if (nextRowChar != 0 && !char.IsWhiteSpace(nextRowChar))
                    {
                        _currDirection = Direction.Down;
                    }
                    else
                    {
                        _currDirection = Direction.Up;
                    }
                }

                return true;
            } else
            {
                return CurrentChar != 0 &&  !char.IsWhiteSpace(CurrentChar);
            }
        }

        private char GetCharAtPosition(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 
                && rowIndex < _inputLines.Length 
                && columnIndex >= 0 
                && columnIndex < _inputLines[rowIndex].Length)
            {
                return _inputLines[rowIndex][columnIndex];

            } else
            {
                return (char)0;
            }
        }
    }
}
