using BabyStroller.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals2
{
    [UnfinishedAnimals]
    public class Pig : IAnimals
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Pig is crying.");
            }
        }
    }
}
