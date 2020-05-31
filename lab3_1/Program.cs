using System;
using System.Linq;

namespace lab3_1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string str = Console.ReadLine();
            char[] delimiters = new[] { ',', '.', ':', ';', '?', '!', ' ' };
            string[] words = (str.Split(delimiters));
            Console.WriteLine("Слова з парною кiлькiстю лiтер:");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length % 2 == 0)
                    Console.WriteLine(words[i]);
            }
            Console.WriteLine("Кiлькiсть знакiв пунктуацiї = " + str.Count(char.IsPunctuation));
            Console.ReadKey(true);
        }
    }
}
