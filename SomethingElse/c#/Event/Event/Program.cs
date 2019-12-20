using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Serve;//事件 += 订阅者.事件处理器
            Console.ReadLine();
            customer.Action();
            customer.PayTheBill();
        }
    }

    public class Waiter
    {
        public void Serve(object sender, EventArgs e1)
        {
            Customer customer;
            customer = sender as Customer;
            OrderEventArgs e;
            e = e1 as OrderEventArgs;

            Console.WriteLine("I'll server you {0}({1}).", e.DishName, e.Size);
            double price = 10;
            if (e.Size == "small")
            {
                price *= 0.5;
            }
            if (e.Size == "large")
            {
                price *= 1.5;
            }
            customer.Bill += price;
        }
    }
    public class Customer
    {
        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine("I'll pay the bill: {0}", Bill);
        }

        public event EventHandler Order;
        //事件其实是对一个委托类型的字段（field）的封装

        //private OrderEventHandler orderEventHandler;

        //public event OrderEventHandler Order
        //{
        //    add
        //    {
        //        this.orderEventHandler += value;
        //    }
        //    remove
        //    {
        //        this.orderEventHandler -= value;
        //    }
        //}

        public void WalkIn()
        {
            Console.WriteLine("I'm walking in");
        }

        public void SitDown()
        {
            Console.WriteLine("I'm sitting down.");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("I'm thinking.");
            }
        }

        protected void OrderTheMeal(string dishName, string size)
        {
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
                this.Order.Invoke(this, e);//触发事件
            }
        }

        public void Action()
        {
            this.WalkIn();
            this.SitDown();
            this.Think();
            this.OrderTheMeal("kongbaochicken", "large");
        }

    }

    //public delegate void OrderEventHandler(object sender, EventArgs e);

    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }
}
