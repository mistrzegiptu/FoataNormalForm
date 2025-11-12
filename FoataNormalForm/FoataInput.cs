using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class FoataInput
    {
        private List<Transaction> _transactions;
        public List<Transaction> Transactions => [.._transactions];
        public Set Set { get; }
        public string Word { get; }

        public FoataInput(List<Transaction> transactions, Set set, string word)
        {
            _transactions = transactions;
            Set = set;
            Word = word;
        }
    }
}
