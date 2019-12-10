using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapterpattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Rect rec = new Rect(100, 100);
            Tri tri = new Tri(100, 100);
            // Area(IRec) 需要一个IRec，不接受Tri；
            // 利用一个TriRecAdaptor把Tri封装成Area接受的类型IRec；
            TriRectAdaptor ada = new TriRectAdaptor(tri);

            Console.WriteLine(Area(rec));
            Console.WriteLine(Area(ada));
            Console.ReadKey();
        }

        static double Area(IRect rec)
        {
            return rec.AreaofRect();
        }
    }


    interface IRect
    {
        double AreaofRect();
    }
    interface ITri
    {
        double AreaofTri();
    }

    class Rect : IRect
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public Rect(double w, double len) { Width = w; Length = len; }
        public double AreaofRect()
        {
            return Width * Length;
        }
    }

    class Tri : ITri
    {
        public Tri(double w, double len)
        {
            Width = w;
            Length = len;
        }
        public double Width { get; set; }
        public double Length { get; set; }
        public double AreaofTri()
        {
            return Width * Length / 2;
        }
    }

    class TriRectAdaptor : IRect
    {
        Tri tri;
        public TriRectAdaptor(Tri tri)
        {
            this.tri = tri;
        }
        public double AreaofRect()
        {
            return tri.AreaofTri();
        }
    }
}
