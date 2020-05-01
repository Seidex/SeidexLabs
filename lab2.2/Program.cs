using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Розмiр масиву: ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];
        int min = -100, max = 100, min1 = array[0], negativeCount = 0, ResSum = 0;
        bool ok = false;
        Console.WriteLine("Рандом - 1, Ввiд - 2");
        int a = int.Parse(Console.ReadLine());
        Random aRand = new Random();
        if(a==2)
            for (int i = 0; i < size; i++)
            {

                Console.Write("A[{0}]: ", i);
                array[i] = int.Parse(Console.ReadLine());
                if (array[i] < 0)
                    negativeCount++;
                if (array[i] < min1)
                    min1 = array[i];
            }
        if (a == 1)
            for (int i = 0; i < size; i++)
            {
                array[i] = aRand.Next(min, max);
                Console.Write("A[{0}]: {1}\n", i, array[i]);
                if (array[i] < 0)
                    negativeCount++;
                if (array[i] < min1)
                    min1 = array[i];
            }
        for (int i = 0; i < size; i++)
        {
            if (ok)
                ResSum += array[i];
            if (array[i] == min1)
                ok = true;
        }
            Console.WriteLine("\nКiлькiсть вiд'ємних: " + negativeCount);
        Console.WriteLine("Сума елементiв пiсля найменшого: " + ResSum);
    }
}