using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Skill = Skill.Drive|Skill.Swim;//枚举类型的位操作，用位或，表示这个person会drive和swim两个技能
            Console.WriteLine(person1.Skill&Skill.Swim);//用位与，看他是否会swim技能
        }
    }

    enum Skill
    {
        //枚举属性设置成1,2,4,8,16...正好是2进制的0001,0010,0100,1000....可以进行位操作
        Drive = 1,
        Swim = 2,
        Program = 4,
        Teach = 8,
    }

    class Person
    {
        public Skill Skill { get; set; }
    }
}
