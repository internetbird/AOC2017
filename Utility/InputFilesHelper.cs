using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2017.Utility
{
    public static class InputFilesHelper
    {
        public static string[] GetInputFileLines (string fileName)
        {
            var fullInputFilePath = Path.GetFullPath($"InputFiles/{fileName}");
            string[] inputStrings = File.ReadAllLines(fullInputFilePath);

            return inputStrings;

        }


        public static string GetInputFileText(string fileName)
        {
            var fullInputFilePath = Path.GetFullPath($"InputFiles/{fileName}");
            string inputText = File.ReadAllText(fullInputFilePath);

            return inputText;
        }

        public static int[] ParseNumbersLine(string line)
        {
            MatchCollection matches = Regex.Matches(line, @"\d+");
        
            return matches.Select(match => int.Parse(match.Value)).ToArray();
        }
    }
}
