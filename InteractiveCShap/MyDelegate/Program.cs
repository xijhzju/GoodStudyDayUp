using System;
namespace ContravariancewithDelegatesEx1
{
    class Vehicle
    {
        public void ShowVehicle(Vehicle myV)
        {
            Console.WriteLine("Vehicle.ShowVehicle");
        }
    }
    class Bus : Vehicle
    {
        public void ShowBus(Bus myB)
        {
            Console.WriteLine("Bus.ShowBus");
        }
    }
    class Program
    {
        public delegate void TakingDerivedTypeParameterDelegate(Bus v);

        public delegate void Mydel2(Vehicle v);
        static void Main(string[] args)
        {
            Vehicle vehicle1 = new Vehicle();//ok
            Bus bus1 = new Bus();//ok
            Console.WriteLine("***Exploring Contravariance with C# delegates * **");
            //General case
            TakingDerivedTypeParameterDelegate del1 = bus1.ShowBus;
            del1(bus1);
            //Special case:
            //Contravariance:
            /*Note that the delegate expected a method that accepts a
            bus(derived) object parameter but still it can point to the
            method that accepts vehicle(base) object parameter*/

            TakingDerivedTypeParameterDelegate del2 = vehicle1.ShowVehicle; //重点！！！！
            //一个接受Bus作为参数的委托可以指向一个接受其父类（Vehicle）作为参数的方法

            del2(bus1); //但调用时需传入Bus对象，如果传入Vehicle对象会报错（因为signature不匹配）。

            //Additional note:you cannot pass vehicle object here
            //del2(vehicle1);//error

            Mydel2 myDel2 = vehicle1.ShowVehicle;
            Mydel2 myDel3 = bus1.ShowBus;   //报错
                                            //委托的参数是Vehicle，不能指向一个接受其子类Bus的方法！
                                            //（否则，你使用这个委托时，只知道这个委托接受Vehicle，可能会传入不符合被指向的方法要求的参数）
                                            //委托的返回类型如果是Vehicle的话，它可以指向一个返回类型是其子类Bus的方法（这里未演示）


            Console.ReadKey();
        }
    }
}