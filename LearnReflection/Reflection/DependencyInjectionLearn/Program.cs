using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            //    ======演示最基本的反射=====
            //    ITank tank = new HeavytTank();

            //    Type t = tank.GetType();
            //    object o = Activator.CreateInstance(t);
            //    MethodInfo fireMI = t.GetMethod("Fire");
            //    MethodInfo runMI = t.GetMethod("Run");

            //    fireMI.Invoke(o, null);
            //    runMI.Invoke(o, null);
            //    ======反射的演示结束=======

            // ======演示依赖注入dependency injection(DI)=====
            //  容器注册
            ServiceCollection sc = new ServiceCollection();
            sc.AddScoped(typeof(ITank), typeof(HeavytTank));
            sc.AddScoped(typeof(IVehicle), typeof(Car));
            sc.AddScoped<Driver>();
            ServiceProvider sp = sc.BuildServiceProvider();

           
            // =============注册好了，之后可以使用配置好的容器了================
            // 之后每次要的ITank利用的都是HeavyTank实例。
            // 如果以后逻辑修改，比如ITank都要用MediumTank实现，直接改注册的地方就可以了。
            // 假设没有使用这种容器的方法，而是每次都ITank tank= new HeavyTank();程序中使用了n次都要每次去修改
            ITank tank = sp.GetService<ITank>();
            tank.Fire();
            tank.Run();

            var driver = sp.GetService<Driver>();// Driver初始化需要IVehicle。容器会自动按已经注册的IVehicle的实例放进去生成Driver的实例
            driver.Run();
     
            Console.ReadKey();
        }

    }

    public class Driver
    {
        private IVehicle _vehicle;
        public Driver(IVehicle vel)
        {
            _vehicle = vel;
        }
        public void Run()
        {
            _vehicle.Run();
        }

    }

    public interface IVehicle
    {
        void Run();
    }
    public interface IWeapon
    {
        void Fire();
    }
    public interface ITank : IVehicle, IWeapon
    { }
    public class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running");
        }
    }
    public class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running");
        }
    }
    public class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("LightTanker fired.");
        }

        public void Run()
        {
            Console.WriteLine("LightTanker is running");
        }
    }
    public class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("MediumTanker fired.");
        }

        public void Run()
        {
            Console.WriteLine("MediumTanker is running");
        }
    }
    public class HeavytTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("HeavyTanker fired.");
        }

        public void Run()
        {
            Console.WriteLine("HeavyTanker is running");
        }
    }

}
