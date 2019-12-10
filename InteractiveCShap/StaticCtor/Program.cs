using System;

namespace StaticConstructorEx1
{
    class A
    {
        //Static field initializers run prior to a static constructor in the declaration order
        static int StaticCount = 0, InstanceCount = 0;
        static A()
        {
            StaticCount++;
            Console.WriteLine("Static constructor.Count={0}", StaticCount);
        }
        public A()
        {
            InstanceCount++;
            Console.WriteLine("Instance constructor.Count={0}",
            InstanceCount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Exploring static constructors***\n");
            A obA = new A();//StaticCount=1,InstanceCount=1
            A obB = new A();//StaticCount=1,InstanceCount=2
            A obC = new A();//StaticCount=1,InstanceCount=3
            Console.ReadKey();
        }
    }
}