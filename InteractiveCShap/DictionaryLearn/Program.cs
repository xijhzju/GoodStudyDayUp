using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryLearn
{
    interface IMyinter
    {
        string this[int i] { get; set; }
    }

    class MyClass1 : IMyinter
    {
        private string[] subject = { "hello", "world", "gogogo", "fire" };
        public string this[int i] { get => subject[i]; set => subject[i]=value; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass1 mc1 = new MyClass1();
            Console.WriteLine(mc1[2]);
            Console.ReadKey();
        }
    }
}
