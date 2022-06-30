using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _3_merging_tables
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split();
            int n = int.Parse(a[0]);
            int m = int.Parse(a[1]);
            long[] tableSizes = new long[n];
            long[] targetTables = new long[m];
            long[] sourceTables = new long[m];
            int j = 0;
            foreach (var item in Console.ReadLine().Split())
                tableSizes[j++] = int.Parse(item);

            for (int i = 0; i < m; i++)
            {
                a = Console.ReadLine().Split();
                targetTables[i] = int.Parse(a[0]);
                sourceTables[i] = int.Parse(a[1]);
            }
            foreach (var item in Solve(tableSizes, targetTables, sourceTables))
                Console.WriteLine(item);
        }
        public class Table {
            public Table parent;
            public long rank;
            public long info;

            public Table(int info,long rank) {
                this.info = info;
                this.rank = rank;
                parent = this;
            }
            public static Table getParent(Table t) {
                while (t.parent != t)
                {
                    t = t.parent;
                }
                return t;
            }
        }
        public static long merge(Table destination, Table source) {
            Table realDestination = Table.getParent(destination);
            Table realSource = Table.getParent(source);
            if (realDestination != realSource) {
                source.parent = realDestination.parent;
                realSource.parent = realDestination.parent;
                destination.rank = realSource.rank + realDestination.rank ;
                source.rank = destination.rank ;
                realDestination.rank = destination.rank;
                realSource.rank = destination.rank ;
                // destination.rank = superparentd.rank;
                // superparents = superparentd;
                // superparentd.rank += superparents.rank;
                // superparents.rank = superparentd.rank;
                // destination.rank = superparentd.rank;
            }
            return destination.rank;
        }
        public static long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        { 
            List<long> result = new List<long>();
            long max = tableSizes.Max();
            List<Table> resultTables = new List<Table>();
            for(int i = 1 ; i <= tableSizes.Length ; i++)
            {
                resultTables.Add(new Table(i,tableSizes[i-1]));
            }
            for(int i = 0 ; i < targetTables.Length; i++)
            {
                long target = targetTables[i];
                long source = sourceTables[i];
                long m = merge(resultTables[(int)target-1],resultTables[(int)source-1]);
                if(m > max)
                    max = m ;
                result.Add(max);
            }
            return result.ToArray();
        }
    }
}
