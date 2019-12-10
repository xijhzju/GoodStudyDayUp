using System;
class Program
{
    public class ClassParent
    {
        public int memberi = MyInt("initialize ClassParent.memberi");

        //public int y = memberi + 2;//初始化不用用其他成员（在方法里可以）

        public ClassParent() { Console.WriteLine("in ClassParent CTOR."); }
        public static int MyInt(string s)
        {
            Console.WriteLine(s);
            return 1;
        }

        ~ClassParent() { MyInt("DeCTOR of ClassParent"); }
    }

    public class ClassChild : ClassParent
    {
        public int members = MyInt("initialize ClassChild.members");
        public ClassChild() { Console.WriteLine("in ClassChild CTOR"); }

        ~ClassChild() { MyInt("DeCTOR of ClassChild"); }
    }

    
    public static void HelpFun() { ClassChild aa = new ClassChild(); }
    static void Main(string[] args)
    {
        ClassChild aa = new ClassChild();//先初始化成员变量，再调用构造函数；
                                   //先初始化子类的成员，再初始化父类的成员。
                                   //先调用父类的CTOR，再调用子类的CTOR。
        Console.WriteLine("=====================");

        HelpFun();
        Console.ReadKey();   //怎么没执行析构函数？
    }
}