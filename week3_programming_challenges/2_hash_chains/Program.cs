using System;
using System.Linq;
using System.Collections.Generic;
namespace _2_hash_chains
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string[] a = new string[2];
            for (int i = 0; i < n; i++)
            {
                a[i] = Console.ReadLine();
            }
            string[] answer = Solve(m,a);
            for (int i = 0; i < answer.Length; i++)
            {
                Console.WriteLine(answer[i]);
            }
        }
        protected static List<string>[] hashtable;
        public  const long ChosenX = 263;
        public static long bucketCounts = 0;
        public static string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            hashtable = new List<string>[bucketCount];
            bucketCounts = bucketCount;
            for (int i = 0; i < hashtable.Length; i++)
            {
                hashtable[i] = new List<string>();
            }
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;

        public static long PolyHash(
            string str, int start, long count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length-1; i >= 0; i--)
            {
                hash = ((hash*x)+str[i])%p;
            }
            return hash % bucketCounts;
        }

        public static void Add(string str)
        {
            long hashed = PolyHash(str, 0, bucketCounts);
            if(hashtable[hashed].Contains(str))
                return;
            hashtable[hashed].Add(str);
        }

        public static string Find(string str)
        {
            long hashed = PolyHash(str, 0, bucketCounts);
            if(hashtable[hashed].Contains(str))
                return "yes";
            return "no";
        }

        public static void Delete(string str)
        {
            long hashed = PolyHash(str, 0, bucketCounts);
            if(hashtable[hashed].Contains(str))
                hashtable[hashed].Remove(str);
        }

        public static string Check(int i)
        {
            string result = "";
            if(hashtable[i].Count == 0)
                return "-";
            for (int j = hashtable[i].Count -1; j >= 0; j--)
            {
                result += hashtable[i][j] + " ";
            }
            return result.TrimEnd();

        }
    }
}
