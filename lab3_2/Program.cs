using System.IO;
using System;
using System.Linq;

namespace lab3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader(@"D:\Labs\lab3\lab3_2\input_nums.txt");
            string s = f.ReadLine();
            Console.WriteLine("s = " + s);
            string[] nums = (s.Split(' '));
            Console.WriteLine("Задайте промiжок [a:b]");
            int a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine()), count=0;
            Console.WriteLine("Чисел на промiжку:");
            for (int i = 0; i < nums.Length; i++)
            {
                int x = int.Parse(nums[i]);
                if (a < x && x < b)
                    count++;
            }
            Console.WriteLine(count);
            f.Close();
            StreamWriter sw = new StreamWriter(@"D:\Labs\lab3\lab3_2\input_nums.txt");
            sw.WriteLine(s);
            sw.WriteLine("Кількість чисел в діапазоні [{0};{1}] = {2}", a, b, count);
            sw.Close();
            Console.ReadKey();
        }
    }
}
