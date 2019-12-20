using System;

namespace testFrameworkVersion
{
    class Program
    {
        static void Main()
        {
            StringEquality();
            Console.ReadKey();
        }
        static void StringEquality()
        {
            Console.WriteLine("=> String equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            // Test these strings for equality.
            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo.Equals(s2): {0}", "Yo!".Equals(s2));
            Console.WriteLine();

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
