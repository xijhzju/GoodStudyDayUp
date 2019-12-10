using BabyStroller.SDK;
using System;

namespace Animals.Lib
{
    public class Cat : IAnimals
    {
        public void Voice(int times)
        {
            while (times > 0)
            {
                Console.WriteLine("Cat is crying.");
                times--;
            }
        }
    }

    public class Dog : IAnimals
    {
        public void Voice(int times)
        {
            while (times > 0)
            {
                Console.WriteLine("Dog is crying.");
                times--;
            }
        }
    }

    public class Cock : IAnimals
    {
        public void Voice(int times)
        {
            while (times > 0)
            {
                Console.WriteLine("Cock is crying.");
                times--;
            }
        }
    }
}
