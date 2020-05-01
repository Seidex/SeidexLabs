using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a; string res = "boi"; bool ok = true;
            Console.WriteLine("Write your month");
            a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1: res = "winter"; break;
                case 2: res = "winter"; break;
                case 3: res = "spring"; break;
                case 4: res = "spring"; break;
                case 5: res = "spring"; break;
                case 6: res = "summer"; break;
                case 7: res = "summer"; break;
                case 8: res = "summer"; break;
                case 9: res = "autumn"; break;
                case 10: res = "autumn"; break;
                case 11: res = "autumn"; break;
                case 12: res = "winter"; break;
                default: ok = false; break;
            }
            if (ok) Console.WriteLine("Time of the year: " + res);
            else Console.WriteLine("Incorrect meaning");
        }
    }
}
