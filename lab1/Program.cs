using System;
namespace lab1
{
    public class Program
    {
        static public int Example(int a)
        {
            int b = a / 100;
            int c = a / 10 % 10;
            int d = a % 10;
            int e = d * 100 + c * 10 + b;
            Console.WriteLine("Отримане число " + e.ToString());
            return e;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть трьохзначне число");
            string S1 = Console.ReadLine();
            int a = int.Parse(S1);
            Example(a);
            Console.ReadLine();
        }
    }
}