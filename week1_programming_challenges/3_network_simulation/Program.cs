using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _3_network_simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split();
            int size = int.Parse(a[0]);
            int n = int.Parse(a[1]);
            List<int[]> packets = new List<int[]>();
            List<int[]> times = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                packets.Add(new int[] { int.Parse(a[0]), int.Parse(a[1]) });
            }
            Console.WriteLine("");
        }
    }
}
