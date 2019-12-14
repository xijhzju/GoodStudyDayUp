using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CtorNonHier
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Vehicle
    {
        public string Owner { get; set; }
        public Vehicle(string owner)
        {
            this.Owner = owner;
        }
    }

    class Car : Vehicle
    {
        //不能缺少这个带参数的构造函数，否则会报错。
        //因为基类有个带参的构造函数就没有了默认的无参构造函数。
        // 而创建子类对象时会先执行基类的构造函数再执行子类的构造函数，
        // 此时会报错（因为没有给基类的构造函数提供参数。
        public Car(string owner) : base(owner)
        {
        }
    }
}
