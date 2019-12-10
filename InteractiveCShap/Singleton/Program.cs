using System;
namespace SingletonPatternEx
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private int numberOfInstances = 0;
        //Private constructor is used to prevent
        //creation of instances with 'new' keyword outside this class
        private Singleton()
        {
            Console.WriteLine("Instantiating inside the private constructor.");

            numberOfInstances++;
            Console.WriteLine("Number of instances ={0}", numberOfInstances);
        }
        public static Singleton Instance
        {
            get
            {
                Console.WriteLine("We already have an instance now.Use it.");
                return instance;
            }
        }
        public static int MyInt = 25;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Singleton Pattern Demo***\n");
            Console.WriteLine(Singleton.MyInt);//main中只涉及静态field MyInt，系统仍然会实例化Singleton，而且还在上一句的输出字符串之前！

            //Private Constructor.So,we cannot use 'new' keyword.
           //Console.WriteLine("Trying to create instance s1.");
           // Singleton s1 = Singleton.Instance;//从输出可以看出时先实例化，再进入Instance的方法体内
           // Console.WriteLine("Trying to create instance s2.");
           // Singleton s2 = Singleton.Instance;
           // if (s1 == s2)
           // {
           //     Console.WriteLine("Only one instance exists.");
           // }
           // else
           // {
           //     Console.WriteLine("Different instances exist.");
           // }
            Console.Read();
        }
    }
}


// https://csharpindepth.com/articles/Singleton
// c#中Singleton的不同代码的对比
namespace Singleton
{ 
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance { get { return lazy.Value; } }

        private Singleton()
        {
        }
    }
}