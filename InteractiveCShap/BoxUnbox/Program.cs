using System;
using System.Diagnostics;
namespace CastingPerformanceComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Analysis of casting performance***\n");
            #region without casting operations
            Stopwatch myStopwatch1 = new Stopwatch();

            myStopwatch1.Start();
            for (int i = 0; i < 100000; i++)
            {
                int j = 25;
                int myInt = j;
                // long m =  j;
            }
            myStopwatch1.Stop();
            Console.WriteLine("Time taken without casting : {0}",
            myStopwatch1.Elapsed);
            #endregion
            #region with casting operations
            Stopwatch myStopwatch2 = new Stopwatch();
            myStopwatch2.Start();
            for (int i = 0; i < 100000; i++)
            {
                double myDouble = 25.5;
                int myInt = (int)myDouble;   //格式转换耗时更多
                //long d = 25;
                //int e = (int)d;//隐式转换耗时比显式少
            }
            myStopwatch2.Stop();
            Console.WriteLine("Time taken with casting: {0}", myStopwatch2.
            Elapsed);
            #endregion
            Console.ReadKey();
        }
    }
}
