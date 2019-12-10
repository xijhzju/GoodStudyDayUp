using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFamate
{
    class Program
    {
        static void Main(string[] args)
        {
            double d1 = 125.854894;
            Console.WriteLine($"{{{d1:n3}}}");//输出{n3}，解读错误！
            //解释见 https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/composite-formatting#escaping-braces
            Console.WriteLine($"{{{d1}}}");//输出{125.854894}正确
            Console.WriteLine($"{d1:n3}");//输出{125.855}四舍五入 正确
            Console.ReadKey();
        }
    }
}
