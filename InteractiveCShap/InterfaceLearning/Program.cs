using System;
namespace InterfaceEx6
{
    interface Interface6
    {
        void ShowInterface6();
    }
    class MyClass6 : Interface6
    {
        void Interface6.ShowInterface6()
        {
            Console.WriteLine("ShowInterface6() is completed.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass6 myClassOb = new MyClass6();
            //  myClassOb.ShowInterface6();//Error  explicit interface methods
                                          //MyClass6明确实现了Interface6.ShowInterface6，这时MyClass6的实例无法使用该方法
            Interface6 ob6 = myClassOb;
            ob6.ShowInterface6();

            Console.ReadKey();
        }
    }
}