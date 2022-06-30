using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _2_tree_height
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split();
            long[] myInts = Array.ConvertAll(a, s => long.Parse(s));
            Console.WriteLine(Solve(n,myInts));
        }
        class Node
        {
            public long item = -2;
            public List<Node> children = new List<Node>();

            public Node()
            {
            }

            public Node(long i)
            {
                item = i;
            }
        }
        public static long Solve(long nodeCount, long[] tree)
        {
            Node[] nodes = new Node[nodeCount];
            long root = 0;
            for(int i = 0 ; i < nodeCount ; i++)
                nodes[i]= new Node();
            for(int child_index = 0 ; child_index < nodeCount ; child_index++)
            {
                long parent_index = tree[child_index];
                if(parent_index==-1)
                    root = child_index;
                else
                {
                    nodes[parent_index].item = parent_index; ;
                    nodes[parent_index].children.Add(new Node(child_index));
                }
            }
            Queue<long> q = new Queue<long>();
            q.Enqueue(root);
            long height = 0;
            while (q.Count != 0) 
            {
                int qCount = q.Count();
                if (qCount == 0)
                    return height;
                height++;
                while (qCount > 0) 
                {
                    long last = q.Dequeue();
                    if (nodes[last].children.Count()!=0)
                    {
                        for(int i = 0; i < nodes[last].children.Count(); i++)
                        {
                            q.Enqueue(nodes[last].children[i].item);
                        }
                    }
                    qCount--;
                }
            }
            return height;
        }
    }
}
