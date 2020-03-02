using System;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing LRUCache with capacity of 2!");
            LRUCache lruCache = new LRUCache(2);
            lruCache.Put(1, 1);
            lruCache.Put(2, 2);
            Console.WriteLine(lruCache.Get(1));
            lruCache.Put(3, 3);
            Console.WriteLine(lruCache.Get(2));
            lruCache.Put(4, 4);
            Console.WriteLine(lruCache.Get(1));
            Console.WriteLine(lruCache.Get(3));
            Console.WriteLine(lruCache.Get(4));
            Console.WriteLine("End of program.");
        }
    }
}
