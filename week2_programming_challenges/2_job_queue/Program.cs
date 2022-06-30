using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _2_job_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a1 = Console.ReadLine().Split();
            string[] a2 = Console.ReadLine().Split();
            int p = int.Parse(a1[0]);
            int n = int.Parse(a1[1]);
            long[] jobs = new long[n];
            for (int i = 0; i < n; i++)
                jobs[i] = int.Parse(a2[i]);
            Tuple<long, long>[] answer = Solve(n,jobs);
            for(int i = 0 ; i < answer.Length ; i++)
                Console.WriteLine(answer[i].Item1 + " " + answer[i].Item2);
        }
        public static Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            List<Tuple<long, long>> result = new List<Tuple<long, long>>();
            List<long[]> tree = new List<long[]>();
            for (int i = 0; i < threadCount; i++)
                tree.Add(new long[]{i,0});
            for (int i = 0; i < jobDuration.Length ; i++)
            {
                result.Add(Tuple.Create(tree[0][0],tree[0][1]));
                tree[0][1] += jobDuration[i];
                siftdown(tree);
            }
            return result.ToArray();
        }
        public static void siftdown(List<long[]> array)
        {
            long i = 0 ;
            while (i<= (int)((array.Count-2)/2))
            {
                long minindex = i ;
                int size = array.Count;
                long left = 2*i+1;
                if(left < size )
                {
                    if(array[(int)left][1] < array[(int)minindex][1])
                        minindex = left;
                    else if(array[(int)left][1] == array[(int)minindex][1])
                    {
                        if(array[(int)left][0] < array[(int)minindex][0])
                            minindex = left;
                    }
                }
                long right = 2*i+2;
                if(right < size )
                {
                    if(array[(int)right][1] < array[(int)minindex][1])
                        minindex = right;
                    else if(array[(int)right][1] == array[(int)minindex][1])
                    {
                        if(array[(int)right][0] < array[(int)minindex][0])
                            minindex = right;
                    }
                }
                if(i != minindex)
                {
                    long[] temp = array[(int)i];
                    array[(int)i] = array[(int)minindex];
                    array[(int)minindex] = temp ;
                    i = minindex;
                }
                else
                    break;
    
            }
        }
    }
}
