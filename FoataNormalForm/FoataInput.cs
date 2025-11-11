using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class FoataInput
    {
        public List<Transaction> Transactions { get; }
        public string Word { get; }

        public FoataInput(List<Transaction> transactions, string word)
        {
            Transactions = transactions;
            Word = word;
        }
    }
}
