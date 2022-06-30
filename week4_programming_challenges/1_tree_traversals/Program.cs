using System;
using System.Collections.Generic;
namespace _1_tree_traversals
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
                lefts[i]= long.Parse(a[1]);
                rights[i]= long.Parse(a[2]);
            }
            foreach (var item in inorder(keys, lefts, rights))
                Console.Write(item + " ");

            Console.WriteLine();
            foreach (var item in preorder(keys, lefts, rights))
                Console.Write(item + " ");

            Console.WriteLine();
            foreach (var item in postorder(keys, lefts, rights))
                Console.Write(item + " ");
        }
        public static long[][] Solve(long[][] nodes)
        {
            List<long> key = new List<long>();
            List<long> left = new List<long>();
            List<long> right = new List<long>();
            for (int i = 0; i < nodes.Length; i++)
            {
                key.Add(nodes[i][0]);
                left.Add(nodes[i][1]);
                right.Add(nodes[i][2]);
            }
            long[][] result = new long[3][];
            result[0] = new long[key.Count];
            result[0] = inorder(key,left,right);
            result[1] = preorder(key,left,right);
            result[2] = postorder(key,left,right);
            return result;
        }

        public static long[] postorder(List<long> key, List<long> left, List<long> right)
        {
            Stack<long> nodes = new Stack<long>(); 
            nodes.Push(0); 
            List<long> result = new List<long>();
            while (nodes.Count!=0) 
            { 
                long current = nodes.Peek(); 
                if (right[(int)current] == -1 && left[(int)current] == -1) 
                { 
                    long node = nodes.Pop();
                    result.Add(key[(int)node]);
                } 
                else 
                { 
                    if (right[(int)current] != -1) 
                    { 
                        nodes.Push(right[(int)current]); 
                        right[(int)current] = -1; 
                    } 
                    if (left[(int)current] != -1) 
                    { 
                        nodes.Push(left[(int)current]); 
                        left[(int)current] = -1; 
                    } 
                }
            }
            return result.ToArray();
        }

        public static long[] preorder(List<long> key, List<long> left, List<long> right)
        {
            Stack<long> nodes = new Stack<long>(); 
            nodes.Push(0); 
            List<long> result = new List<long>();

            while (nodes.Count!=0) 
            { 
                long current = nodes.Pop(); 
                result.Add(key[(int)current]); 
                if (right[(int)current] != -1) 
                { 
                    nodes.Push(right[(int)current]); 
                } 
                if (left[(int)current] != -1) 
                { 
                    nodes.Push(left[(int)current]); 
                }
            };return result.ToArray();
        }

        public static long[] inorder(List<long> key, List<long> left, List<long> right)
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
            return result.ToArray();
        }
    }
}
