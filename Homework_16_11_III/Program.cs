using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16_11_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] arr = new int[20];
            for (int i = 0; i < 20; i++)
            {
                arr[i] = rand.Next(10, 51);
            }

            Console.WriteLine("Начальный массив: ");
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            int prime_count = 0;

            Task t1 = Task.Run(() =>
            {
                Console.WriteLine("Только простые числа:");
                for (int i = 0; i < arr.Length; i++)
                {
                    int count = 0;

                    for (int j = 1; j <= arr[i]; j++)
                    {
                        if (arr[i] % j == 0)
                        {
                            count++;
                        }

                        if (count > 2)
                        {
                            break;
                        }
                    }

                    if (count == 2)
                    {
                        Console.WriteLine(arr[i]);
                        prime_count++;
                    }
                }
            });
            t1.Wait();

            Console.WriteLine($"Простых чисел: {prime_count}");

            Console.Read();
        }
    }
}
