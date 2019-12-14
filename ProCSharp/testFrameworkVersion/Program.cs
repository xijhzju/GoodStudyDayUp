using System;

namespace testFrameworkVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myArgs = Environment.GetCommandLineArgs();//也可以得到命令行参数

            Console.WriteLine($"myArgs.Length={myArgs.Length}");
            Console.WriteLine("myArgs:");
            foreach (var str in myArgs)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("===============");
            Console.WriteLine($"args.Length={args.Length}");
            Console.WriteLine("args：");
            foreach (var str in args)
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }
    }
}
