using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutRefArgue
{
    class Program
    {
        int Change(int a)
        {
            a = 25;
            return a;
        }

        int Change(ref int a)//ref参数传入前必须已经初始化！（与out区别）
        {
            a = 25;
            return a;
        }

        //int Change(out int a)//参数只有out和ref的差别不能同时存在！  out参数传入前可以未初始化。方法内out参数必须赋值。
        //{
        //    a = 25;
        //    return a;
        //}
        static void Main(string[] args)
        {
        }
    }
}
