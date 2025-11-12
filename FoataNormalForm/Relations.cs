using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class Relations
    {
        private List<Transaction> _transactions;
        public List<(Transaction, Transaction)> _dependenceSet;
        public List<(Transaction, Transaction)> _independenceSet;

        public void BuildSets(List<Transaction> transactions)
        {
            _transactions = transactions;

            //Beauty of LINQ :)
            var crossTransactions = transactions.SelectMany(t => transactions, (t, t1) => (t, t1));

            _dependenceSet = crossTransactions.Where(x => x.t.AreInRelation(x.t1)).ToList();
            _independenceSet = crossTransactions.Where(x => !x.t.AreInRelation(x.t1)).ToList();
        }

        public bool AreDependent(Transaction transactionA, Transaction transactionB)
        {
            return _dependenceSet.Contains((transactionA, transactionB)) ||
                   _dependenceSet.Contains((transactionB, transactionA));
        }

        public bool AreDependent(string transactionALabel, string transactionBLabel)
        {

            var transactionA = _transactions.FirstOrDefault(t => t.Label == transactionALabel);
            var transactionB = _transactions.FirstOrDefault(t => t.Label == transactionBLabel);

            return AreDependent(transactionA, transactionB);
        }

        public void PrintDependenceSet()
        {
            Console.Write("D = {");
            foreach (var relation in _dependenceSet)
            {
                Console.Write("(" + relation.Item1.Label + "," + relation.Item2.Label + "),");
            }
            Console.WriteLine("}");
        }

        public void PrintIndependenceSet()
        {
            Console.Write("I = {");
            foreach (var relation in _independenceSet)
            {
                Console.Write("(" + relation.Item1.Label + "," + relation.Item2.Label + "),");
            }
            Console.WriteLine("}");
        }
    }
}