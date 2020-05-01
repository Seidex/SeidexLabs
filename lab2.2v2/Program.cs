using System;

namespace lab2._2v2
{
    public class  Program
    {
        static public int negCount(int[] arr, int n)
        {
            int negC = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                    negC++;
            }
            return negC;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("К-сть елементiв масиву: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("Задайте елементи масиву: ");
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());
            int negC = negCount(arr, n);
            Console.WriteLine("К-сть вiд'ємних елементв: {0} ", negC);
        }
    }
}
