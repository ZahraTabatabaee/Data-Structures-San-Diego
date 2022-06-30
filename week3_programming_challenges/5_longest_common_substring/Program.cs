using System;

namespace _5_longest_common_substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
        public long[] Solve(string pattern, string text)
        {
            List<long> occurrences = new List<long>();
            long BigPrimeNumber = 1000000007;
            long x = 263;
            long pHash = PolyHash(pattern,BigPrimeNumber,x);
            long[] H = PreComputeHashes(text,pattern.Length,BigPrimeNumber,x);
            for(int i = 0; i <= text.Length - pattern.Length; i++)
            {
                if(H[i]!= pHash)
                    continue;
                if (text.Substring(i,pattern.Length).Equals(pattern))
                    occurrences.Add(i);
            }
            return occurrences.ToArray();
        }
        // array
        public static long PolyHash(
            string str, long primeNumber, long x)
        {
            long hash = 0;
            for (int i = str.Length-1; i >= 0; i--)
            {
                hash = ((hash*x)+str[i])%primeNumber;
            }
            return hash;
        }
        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {
            long[] h = new long[T.Length-P+1];
            string s = T.Substring(T.Length-(int)P,P);
            h[T.Length-P] = PolyHash(s,p,x);
            long y = 1 ;
            for (int i = 1; i <P+1 ; i++)
                y = (y*x)%p ;
            for (int i = T.Length-P-1; i >= 0 ; i--)
                h[i] = ((x*h[i+1]+ T[i] - y*T[i+P])%p +p)%p ;
            return h;
        }
    }
}
