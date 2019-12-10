using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learn2
{
    public class A
    {
        private void PrivateMethod() { Console.WriteLine("in Private Method of Class A"); }
        public void PubliceMethod() { Console.WriteLine("in PublicMethod"); PrivateMethod(); Console.WriteLine("in PublicMethod") ; }
    }

    public class B : A
    { 
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            b.PubliceMethod();//子类继承父类的所有东西（包括pravite，但不包括构造函数和析构函数----那为什么实例化子类对象时会执行父类的构造函数？）
                              //    b.PrivateMethod();//Error CS0122  'A.PrivateMethod()' is inaccessible due to its protection level 
                              //     b.NoThisMember;//B does not contain a definition for "NoThisMember" ....
            A a = new A();
            B c = a as B;//无法转换，c=null；
            // B c = (B)a;//报错，无法转换
            // c.PubliceMethod();//报错
			// 修改 测试上传github效果
			// 二次修改测试git status
            Console.ReadKey();
        }
    }
}
