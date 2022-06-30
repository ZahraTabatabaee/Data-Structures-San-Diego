using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _1_make_heap
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] a = new long[n];
            int i = 0;

            foreach (var item in Console.ReadLine().Split())
            {
                a[i] = int.Parse(item);
                i++;
            }
            Tuple<long, long>[] answer = Solve(a);

            Console.WriteLine(answer.Count());
            for (int j = 0; j < answer.Count(); j++)
            {
                Console.WriteLine(answer[j].Item1 + " " + answer[j].Item2);
            }
        }
        public static Tuple<long, long>[] Solve(long[] array)
        {
            int size = array.Length;
            int idx = 0;
            List<Tuple<long, long>> result = new List<Tuple<long, long>>();
            for (int i = size/2-1  ; i >= 0 ; i--)
            {
                siftdown(i,array,result,idx);
            }
            return result.ToArray();
        }

        public static void siftdown(long i , long[] array, List<Tuple<long, long>> result, int idx)
        {
            long minindex = i ;
            int size = array.Length;
            long left = 2*i+1;
            if(left < size && array[left] < array[minindex])
                minindex = left;
            long right = 2*i+2;
            if(right < size && array[right] < array[minindex])
                minindex = right;
            if( i != minindex )
            {
                long temp = array[i];
                array[i] = array[minindex];
                array[minindex] = temp ;
                result.Add(new Tuple<long, long>(i,minindex));
                idx++;
                siftdown(minindex,array,result,idx);
            }
        }
    }
}
