using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHashTable
{
    public class MyHashTable<TValue>
    {
        private int HashTableSize=0;

        private int count = 0;

        private readonly Node<TValue>[] buckets;

        public MyHashTable(int size)
        {
            if(size>0)
            {
                HashTableSize = size;
            }
            buckets = new Node<TValue>[HashTableSize];
        }

        public TValue Get(string key)
        {
            ValidateKey(key);
            var (x, node) = GetNodeByKey(key);
            if (node == null)
                throw new ArgumentOutOfRangeException(nameof(key), $"The key '{key}'is not found!");

            return node.Value;
        }

        public void Put(string key, TValue item)
        {
            ValidateKey(key);
            var valueNode = new Node<TValue> { Key = key, Value = item, Next = null };
            int index = Indexer(key);
            Node<TValue> listNode = buckets[index];
            if (null == listNode)
            {
                buckets[index] = valueNode; 
            }
            else
            {
                while (null != listNode.Next)
                {
                    listNode = listNode.Next;
                }
                listNode.Next = valueNode;

            }
            HashTableSize++;
            count++;
        }

        public bool Remove(string key)
        {
            ValidateKey(key);
            int position = Indexer(key);
            var (prev, node) = GetNodeByKey(key);
            if (node == null)
            {
                return false;
            }
            if (prev == null)
            {
                HashTableSize--;
                buckets[position] = null;
                return true;
            }
            prev.Next = node.Next;
            HashTableSize--;
            count--;
            return true;
        }

        public bool ContainsKey(string key)
        {
            ValidateKey(key);
            var (x, node) = GetNodeByKey(key);
            return null != node;
        }

        public int Count()
        {
            return count;
        }

        private void ValidateKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
        }
        private int Indexer(string key)
        {
            return Math.Abs(key.GetHashCode() % buckets.Length);

        }

        private (Node<TValue> prev, Node<TValue> current) GetNodeByKey(string key)
        {
            int position = Indexer(key);
            Node<TValue> listNode = buckets[position];
            Node<TValue> prev = null;
            while (listNode != null) 
            {
                if (listNode.Key == key)
                { 
                    return (prev, listNode); 
                }
                prev = listNode;
                listNode = listNode.Next;
            }
            return (null, null);
        }
    }
}
