using BabyStroller.SDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace BabyStroller
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(Environment.CurrentDirectory); 显示当前工作目录---实际工作的程序的目录，不是源程序
            string folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            string[] files = Directory.GetFiles(folder);
            List<Type> animalTypes = new List<Type>();

            // 导入文件中的动物类型
            foreach (var file in files)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    // if (t.GetMethod("Voice") != null)   {   animalTypes.Add(t);  }  //使用IAnimals前可以用此语句添加动物类
                    if (t.GetInterfaces().Contains(typeof(IAnimals)))   //Contains 是Linq的语句
                    {
                        //认真学习下面这句话……
                        var isUnfinished = t.GetCustomAttributes(false).Any(a => a.GetType() == typeof(UnfinishedAnimalsAttribute));
                        if (!isUnfinished)
                        {
                            animalTypes.Add(t);
                        }
                    }
                }
            }

            while (true)
            {
                for (int i = 0; i < animalTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{animalTypes[i].Name}");
                }
                Console.WriteLine("========================");
                Console.WriteLine("please choose an animal");
                int index = int.Parse(Console.ReadLine());
                if (index > animalTypes.Count || index < 1)
                {
                    Console.WriteLine("NO such animal, please try again");
                    continue;
                }
                Console.WriteLine("please input times of voice");
                int times = int.Parse(Console.ReadLine());
                var t = animalTypes[index - 1];
                var m = t.GetMethod("Voice");
                var o = Activator.CreateInstance(t);
                // m.Invoke(o, new object[] { times });
                var a = o as IAnimals;
                a.Voice(times);
            }
        }
    }
}
