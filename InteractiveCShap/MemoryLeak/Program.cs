using System;
using System.Collections.Generic;
namespace AnalyzingLeaksWithSimpleEventEx1
{
    public delegate string MyDelegate(string str);
    class SimpleEventClass
    {
        public int ID { get; set; }
        public event MyDelegate SimpleEvent;
        public SimpleEventClass()
        {
            /*We can see how the heap size is growing over time. If you notice carefully, you’ll see
                that we are registering an event in our code
                SimpleEvent += new MyDelegate(PrintText);
                but never unregistered it.*/
            //原文如是说，但我不是特别明白，这里还需要SimpleEvent -=...这样还是啥意思？
            //可能是：
            //实例化SimpleEventClass对象后，它的事件绑定了一个委托对象。
            //当这个对象删除后，析构函数没有把绑定的new MyDelegate(PrintText) 删除。
            SimpleEvent += new MyDelegate(PrintText);
        }
        public string PrintText(string text)
        {
            return text;
        }
        static void Main(string[] args)
        {
            IDictionary<int, SimpleEventClass> col = new Dictionary<int, SimpleEventClass>();
            for (int objectNo = 0; objectNo < 500000; objectNo++)
            {
                col[objectNo] = new SimpleEventClass { ID = objectNo };
                string result = col[objectNo].SimpleEvent("Raising an event ");
                Console.WriteLine(objectNo);
            }

            Console.ReadKey();
        }
    }
}
