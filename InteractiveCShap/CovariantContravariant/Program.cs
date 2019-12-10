using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovariantContravariant
{
    class Person
    {
        public virtual void Show()
        { Console.WriteLine("I'm a person."); }
    }

    class Student : Person
    {
        public override void Show()
        {
            Console.WriteLine("I'm a student");
        }
    }

    class GoodStudent : Student
    {
        public override void Show()
        {
            Console.WriteLine("I'm a good student");
        }
    }

    delegate void MyDel<T>(T t);//委托的输入参数逻辑上就是逆变的，不管你有没有写in关键字。写in关键字只是提醒程序员这是逆变的。
    class Program
    {
        static public Student test3(Person p)
        {
            p.Show();
            return new Student();
        }

        static public void test4(Person s)
        {
            s.Show();
            //return new Student();
        }

        static void Main(string[] args)
        {

            Func<Student, Person> myFuc = test3; //Func输入输出参数，输入符合Contravariant，Student可以用Person。
                                                 //但输出符合covariance，Person可以用Student。
                                                 //这里委托要求输入Student，输出Person。使用的方法输入时Person，输出时Student。
                                                 //逆变使得委托实例上的目标方法可以接收更抽象的参数(委托要求child，目标方法可以输入parent。）
                                                 //                                           （使用时按委托要求输入child，不影响目标方法的执行！）
                                                 //协变使得委托实例上的返回类型可以更加具体（委托要求输出parent，目标方法可以输出child）
                                                 //Func<in T,out TResult> 输入有in关键字表示逆变，输出有out关键字，表示协变。 
            Person person = new Person();
            Student student = new Student();
            myFuc(new GoodStudent());

            MyDel<Student> mydel = test4;
            mydel(new GoodStudent());
            Console.ReadKey();
        }
    }
}
