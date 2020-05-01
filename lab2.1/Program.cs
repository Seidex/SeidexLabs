using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double b = - Math.PI / 2, a = (-3 * Math.PI) / 2, dx = Math.PI / 10, x, y;
            Console.WriteLine("|           x          ||           y           |");
            x = a;
            while (x <= b) { 
            y = Math.Pow(x, 2) * Math.Cos(x);
                Console.WriteLine($"| {x}   |   {y}  |");
                x += dx;
            }
        }
    }
}
