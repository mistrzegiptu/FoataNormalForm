using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal static class DependenceRelation
    {
        public static bool AreInRelation(this Transaction transaction, Transaction anotherTransaction)
        {
            return transaction.Operations.Contains(anotherTransaction.Variable) ||
                   anotherTransaction.Operations.Contains(transaction.Variable);
        }
    }
}
