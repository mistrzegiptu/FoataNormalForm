using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class InputParser
    {
        private const string _transactionPattern = @"\(([a-z])\) ([a-z]) \:\= ([a-z\d\+\-\*\/\s]+)";
        private const string _setPattern = @"([A-Z]) \= \{(.+)\}";
        private const string _wordPattern = @"([a-z]) \= ([a-z]+)";

        private static readonly List<Transaction> _transactions = [];
        private static Set _set;
        private static string _word;

        public static FoataInput ParseFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return new FoataInput(_transactions, _set, _word);
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

                var operations = rawOperations.Split('+', '-', '*', '/').Select(o => o.Trim())
                    .Select(o => o.Length == 1 ? o : o[^1].ToString()).ToList();

                var transaction = new Transaction(label, variable, operations);
                _transactions.Add(transaction);
            }
            else
            {
                var setMatch = Regex.Match(line, _setPattern);
                if (setMatch.Success)
                {
                    var groups = setMatch.Groups;
                    var label = groups[1].Value;
                    var rawVariables = groups[2].Value;

                    var variables = rawVariables.Split(", ");
                    _set = new Set(label, [..variables]); //Spread element operator - actually interesting
                }
                else
                {
                    var wordMatch = Regex.Match(line, _wordPattern);
                    if (wordMatch.Success)
                    {
                        var groups = wordMatch.Groups;

                        _word = groups[2].Value;
                    }
                    else
                    {
                        throw new ArgumentException("File is not proper");
                    }
                }
            }
        }
    }
}
