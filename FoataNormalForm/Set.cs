using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class Set
    {
        private HashSet<string> _values;

        public string Label { get; }
        public HashSet<string> Values => [.._values];

        public Set(string label, HashSet<string> values)
        {
            Label = label;
            _values = values;
        }
    }
}
