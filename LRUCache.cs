using System;
using System.Collections.Generic;

namespace LRUCache
{
    public class LRUCache
    {
        private int _capacity;
        private Dictionary<int, LinkedNode> lruDictionary;
        private LinkedNode first, last;

        public LRUCache(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Capacity cannot be zero or negative.");
            }

            _capacity = capacity;
            lruDictionary = new Dictionary<int, LinkedNode>();
        }

        public int Get(int key)
        {
            LinkedNode nodeToGet;

            if (!lruDictionary.TryGetValue(key, out nodeToGet))
            {
                return -1;
            }
            removeNode(nodeToGet);
            addAtTop(nodeToGet);

            return nodeToGet.Value;
        }

        public void Put(int key, int value)
        {
            // Input sanitization
            if (key <= 0)
            {
                throw new ArgumentOutOfRangeException("Key cannot be zero or negative.");
            }

            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Value cannot be negative.");
            }

            LinkedNode newNode = new LinkedNode(key, value);

            // Do work
            if (lruDictionary.Count == _capacity)
            {
                lruDictionary.Remove(last.Key);
                removeNode(last);
                addAtTop(newNode);
            }
            else
            {
                addAtTop(newNode);
            }

            lruDictionary.Add(newNode.Key, newNode);
        }

        private void addAtTop(LinkedNode nodeToAdd)
        {
            nodeToAdd.right = first;
            nodeToAdd.left = null;

            if (first != null)
            {
                first.left = nodeToAdd;
            }

            first = nodeToAdd;

            if (last == null)
            {
                last = first;
            }
        }

        private void removeNode(LinkedNode nodeToRemove)
        {
            if (nodeToRemove.left != null)
            {
                nodeToRemove.left.right = nodeToRemove.right;
            }
            else
            {
                first = nodeToRemove.right;
            }

            if (nodeToRemove.right != null)
            {
                nodeToRemove.right.left = nodeToRemove.left;
            }
            else
            {
                last = nodeToRemove.left;
            }
        }
    }

    class LinkedNode
    {
        public LinkedNode(int key, int value)
        {
            Key = key;
            Value = value;
        }
        public int Key { get; private set; }
        public int Value { get; private set; }
        public LinkedNode left { get; set; }
        public LinkedNode right { get; set; }
    }
}