using System;
using System.Collections.Generic;
using System.Linq;
namespace _2_is_bst
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<long> keys = new List<long>();
            List<long> lefts = new List<long>();
            List<long> rights = new List<long>();
            string[] a = new string[3];
            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                keys[i] = long.Parse(a[0]);
                lefts[i] = long.Parse(a[1]);
                rights[i] = long.Parse(a[2]);
            }
            bool result = Solve(keys,lefts,rights);
            if(result) 
                Console.WriteLine("CORRECT");
            else 
                Console.WriteLine("INCORRECT");
        }
        public static bool Solve(List<long> key,List<long> left,List<long> right)
        {
            List<long> result = new List<long>();
            List<long> Sorted = new List<long>();
            result = inorder(key,left,right);
            for (int i = 0; i < result.Count; i++)
            {
                Sorted.Add(result[i]);
            }
            Sorted.Sort();
            var a = Sorted.SequenceEqual(result);
            return a;
        }
        public static List<long> inorder(List<long> key, List<long> left, List<long> right)
        {
            Stack<long> nodes = new Stack<long>(); 
            long current = 0; 
            List<long> result = new List<long>();
            while (nodes.Count!=0 || current != -1) 
            { 
                if (current != -1) 
                { 
                    nodes.Push(current);
                    current = left[(int)current]; 
                } 
                else 
                { 
                    long node = nodes.Pop(); 
                    result.Add(key[(int)node]);
                    current = right[(int)node]; 
                } 
            }
            return result;
        }
    }
}
