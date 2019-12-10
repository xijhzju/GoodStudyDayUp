using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCompare
{
    class Employee
    {
        public int ID { get; set; }
        public string Department { get; set; }
        public Employee(int id, string dep)
        {
            ID = id;
            Department = dep;
        }

        static public bool ComEmp(Employee e1, Employee e2)
        {
            if ((e1.ID == e2.ID) && (e1.Department==e2.Department))  
            {
                return true;
            }
            return false;
        }

        public bool ComEmp(Employee e1)
        {
            if ((ID == e1.ID) && (e1.Department == Department))
            {
                return true;
            }
            return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee(23, "HR");
            Employee e2 = new Employee(11, "Sto");
            Employee e3 = new Employee(11, "Sto");
            bool b1 = Employee.ComEmp(e1, e2);
            bool b2 = Employee.ComEmp(e2, e3);

            bool b3 = e1.ComEmp(e2);
            bool b4 = e2.ComEmp(e3);

            Console.WriteLine(b1+"   "+b2+"  "+b3+"  "+b4);
            Console.ReadKey();
        }
    }
}
