using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_16_11_IV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10] { 5, 21,1, 15,45, 12,53, 2, 9, 6};
            Mutex mutex = new Mutex();

            Task[] t1 = new Task[4]
            {
                new Task(() =>
                {
                    mutex.WaitOne();
                    for (int i = 0; i < 1; i++) 
                    {
                        Console.WriteLine($"Минимум: {arr.Min()}");
                    }
                    mutex.ReleaseMutex();
                }),

                new Task(() =>
                {
                    mutex.WaitOne();
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine($"Максимум: {arr.Max()}");
                    }
                    mutex.ReleaseMutex();
                }),

                new Task(() =>
                {
                    mutex.WaitOne();
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine($"Среднее арифметическое: {arr.Average()}");
                    }
                    mutex.ReleaseMutex();
                }),

                new Task(() =>
                {
                    mutex.WaitOne();
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine($"Сумма элементов: {arr.Sum()}");
                    }
                    mutex.ReleaseMutex();
                })
            };

            foreach (var item in t1)
            {
                item.Start(); 
            }
            Console.Read();
        }
    }
}
