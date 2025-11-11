using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class Transaction
    {
        public string Label { get; }
        public string Variable { get; }
        public List<string> Operations { get; }

        public Transaction(string label, string variable, List<string> operations)
        {
            Label = label;
            Variable = variable;
            Operations = operations;
        }
    }
}
