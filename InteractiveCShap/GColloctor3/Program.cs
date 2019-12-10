using System;
namespace GarbageCollectionEx1._1
{
    class MyClassA : IDisposable
    {
        MyClassB classBObject;
        class MyClassB : IDisposable
        {
            public int Diff(int a, int b)
            {
                return a - b;
            }
            public void Dispose()
            {
                GC.SuppressFinalize(this);
                Console.WriteLine("MyClass B:Dispose() is called");
            }
            ~MyClassB()
            {
                Console.WriteLine("MyClassB:Destructor is Called..");
                System.Threading.Thread.Sleep(5000);
            }
        }
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public int Diff(int a, int b)
        {
            classBObject = new MyClassB();
            return classBObject.Diff(a, b);
        }
        public void Dispose()
        {
            //调用Dispost()方法会调用SuppressFinalize（）方法,此方法会阻止析构函数/Finalize（）的调用
            //all .Net classes that have an unmanaged resource provide a Finalizer to make sure that they will normally be freed at some point.
            /*Normally such unmanaged resources will be freed in two places:
              1：The Dispose() method.This should be the normal way that you dispose unmanaged resources.
              2：The Finalizer. This is a last - resort mechanism.If a class has a finalizer it will be called
                 by the Garbage Collector when it cleans up a dead object. Any class which has an unmanaged resource 
                 should have a finalizer to clean up if the programmer forgets to call Dispose().
                 垃圾回收会自动调用Finalizer */

            // This object will be cleaned up by the Dispose method. Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue and prevent finalization code for this object from executing a second time.
            // 调用Dispose方法应该调用SupressFinalize方法，以防止重复释放资源。
            GC.SuppressFinalize(this);
            Console.WriteLine("MyClassA:Dispose() is called");
            //classBObject.Dispose(); 
        }
        ~MyClassA()
        {
            Console.WriteLine("MyClassA:Destructor is Called..");
            System.Threading.Thread.Sleep(5000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Quiz:Exploring Garbage Collections.* **");
            MyClassA obA = new MyClassA();
            int sumOfIntegers = obA.Sum(100, 20);
            int diffOfIntegers = obA.Diff(100, 20);
            Console.WriteLine("Sum of 10 and 20 is:{0}", sumOfIntegers);
            Console.WriteLine("Difference of 10 and 20 is:{0}",
            diffOfIntegers);
            obA.Dispose();
            Console.ReadKey();
        
        }
    }
}