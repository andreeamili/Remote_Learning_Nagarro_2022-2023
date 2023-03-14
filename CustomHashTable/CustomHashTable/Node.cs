using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHashTable
{
    internal class Node<TValue>
    {
        public Node<TValue> Next { get; set; }

        public string Key { get; set; }

        public TValue Value { get; set; }
    }
}
