using BabyStroller.SDK;
using System;

namespace Animals2
{
    public class Fox : IAnimals
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Fox is crying.");
            }
        }
    }
}
