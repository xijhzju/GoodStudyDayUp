using System;

namespace ReturnMainValue
{
    class Program
    {
        static int Main(string[] args)
        {
            string[] myArgs = Environment.GetCommandLineArgs();//也可以得到命令行参数

            Console.WriteLine($"myArgs.Length={myArgs.Length}");
            Console.WriteLine($"args.Length={args.Length}");
            // 从运行情况看：args就是实际的命令行参数构成的string数组
            // 而myArgs的第一个成员myArgs[0]是对应程序dll的名字！之后才是具体的参数。
            // 但看书中page121/1410的运行情况，myArgs中不包括dll的名字，也就是跟args一样。为啥？？
            foreach (var str in myArgs) 
            {
                Console.WriteLine(str);
            }


            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("No Parameter.");
                }
                if (int.TryParse(args[0], out int r))
                {
                    return r;
                }
                else throw new Exception("Parameter should be int.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}
