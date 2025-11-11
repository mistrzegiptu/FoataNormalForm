using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class InputParser
    {
        private static readonly string _transactionPattern = "\\(([a-z])\\) ([a-z]) \\:\\= ([a-z\\d\\+\\-\\*\\/\\s]+)";
        private static readonly string _setPattern = "[A-Z] \\= \\{.+\\}";

        public static void ParseFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            
            foreach (var line in lines)
            {
                ParseLine(line);
            }
        }

        private static void ParseLine(string line)
        {
            var matchTransaction = Regex.Match(line, _transactionPattern);
            if (matchTransaction.Success)
            {
                var groups = matchTransaction.Groups;

                var label = groups[1].Value;
                var variable = groups[2].Value;
                var rawOperations = groups[3].Value;

                var operations = rawOperations.Split('+', '-', '*', '/').Select(o => o.Trim()).ToList();
            }
            else
            {
                var setMatch = Regex.Match(line, _setPattern);
            }
        }
    }
}
