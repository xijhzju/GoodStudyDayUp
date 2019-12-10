using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

sealed class MyClass
{
    public static int x = 10;

    private static MyClass myClass = new MyClass();
    private MyClass()
    {
        Console.WriteLine("In MyClass Instantiation.");
    }
    public static void Test()
    {
        Console.WriteLine("In MyClass.Test()");
    }
}

namespace MyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's try something.");
            Console.WriteLine(MyClass.x);
            //输出In MyClass Instantiation.
            //   Let's try something.
            //   10
            //虽然只引用了MyClass.x, 但涉及MyClass类的静态对象，所以会对MyClass进行初始化。
            //此时同样需要初始化MyClass类里面的静态对象MyClass myClass=new M有Class（）；
            //调用了MyClass的构造函数，产生输出In MyClass Instantiation.
            //以上涉及的初始化并不知道会在什么时候发生!!!
            //所以初始化并不是一定在输出Let's try something.之后调用MyClass.x才初始化。

            Console.ReadKey();
        }
    }
}
