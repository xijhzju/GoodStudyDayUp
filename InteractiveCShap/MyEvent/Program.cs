using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEvent
{
    public class TeacherEventArgs : EventArgs
    {
        public string ForWhat { get; set; }
    }
    public class Teacher
    {
        public delegate void TeacherComingEventHandler(object sender, TeacherEventArgs e);

        public TeacherEventArgs teacherEventArgs;
        public event TeacherComingEventHandler TeacherComing;//event可以去掉！其实就是个委托类型的变量！
        public void TeacherRun()
        {
            Console.WriteLine("Teacher is running");
            Console.WriteLine("Teacher coming");
            OnTeacherComing();
        }
        protected virtual void OnTeacherComing()
        {
            if (TeacherComing != null)
            {
                TeacherComing(this, teacherEventArgs);
            }
        }
    }

    public class Student
    {
        public void OnTeachercoming(object o, TeacherEventArgs e)
        {
            Console.WriteLine("Stop Watching Cellphone");
            Console.WriteLine("Begin Reading");
            Console.WriteLine("Teacher:\"I'm coming for " + e.ForWhat+" \"");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Teacher teacherChen = new Teacher();
            TeacherEventArgs tea = new TeacherEventArgs();
            teacherChen.teacherEventArgs = tea;
            teacherChen.teacherEventArgs.ForWhat = "EXAM";
            Student stu1 = new Student();
            Student stu2 = new Student();
            teacherChen.TeacherComing += stu1.OnTeachercoming;
            teacherChen.TeacherComing += stu2.OnTeachercoming;

            teacherChen.TeacherRun();
            Console.ReadKey();
        }
    }
}
