using System;

namespace lab2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("К-сть рядкiв: ");
            int s1 = int.Parse(Console.ReadLine());
            Console.WriteLine("К-сть стовпцiв: ");
            int s2 = int.Parse(Console.ReadLine());
            int min = -100, max = 100, i, j, max1;
            int[,] arr = new int[s1, s2];
            Random rnd = new Random();
            Console.WriteLine("Рандом - 2, Ввiд - 1");
            int a = int.Parse(Console.ReadLine());
            if (a == 2)
            {
                for (i = 0; i < s1; i++)
                {
                    for (j = 0; j < s2; j++)
                    {
                        arr[i, j] = rnd.Next(min, max);
                        Console.Write("| {0}  | ", arr[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            if (a == 1)
            {
                for (i = 0; i < s1; i++)
                {
                    for (j = 0; j < s2; j++)
                    {
                        Console.Write("| {0}{1} | ", i, j);
                        arr[i, j] = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Максимальнi елементи рядкiв:");
                for (j = 0; j < s2; j++)
                {
                    max1 = arr[0,j];
                    for (i = 1; i < s1; i++)
                        if (arr[i,j] > max1)
                            max1 = arr[i,j];
                Console.Write("| {0}  | ", max1);
                }
        }
    }
}
